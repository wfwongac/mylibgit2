#NAME:		Wong Wai Fun
#ID:		20138073	
#EMAIL:		wfwongac@connect.ust.hk

#=========================#
#   THE REVENGE of PIGS   #
#=========================#

#---------- DATA SEGMENT ----------
	.data
pig:	.word 0:399   
# assuming game object size 30x30
width:  .word 510    # 510 game board width
height: .word 505    # 450 game board height plus some space (55) for game state info
bird:	.word 240 210	#Putting the Bird at the center of the board
msg0:	.asciiz "Enter the number of Pigs you want? "
msg1:	.asciiz "Invalid size!\n"
msg2:	.asciiz "Enter the seed for random number generator? "
msg3:	.asciiz "Red bird was captured!"
msg4:	.asciiz "Score: "
msg5:	.asciiz "Slingshot: "
msg6:	.asciiz "Level: "
space: .asciiz " "
newline: .asciiz "\n"

title: .asciiz "The Revenge of Pigs"
pig_symbol:	.asciiz "pig.gif"
bird_symbol1:	.asciiz	"bird1.gif"
bird_symbol2:	.asciiz	"bird2.gif"
skull_symbol:	.asciiz	"skull.gif"
backgroundImg: .asciiz "background.gif"
images: .word 0:4  # array for file name of all game images


#---------- TEXT SEGMENT ----------
	.text
	.globl __start
__start:


main:
#-------(Start main)------------------------------------------------

	jal setting				# the game setting

	# create image file name array
	la $t0, images
	la $t1, bird_symbol1
	sw $t1, 0($t0)

	la $t1, bird_symbol2
	sw $t1, 4($t0)

	la $t1, pig_symbol
	sw $t1, 8($t0)

	la $t1, skull_symbol
	sw $t1, 12($t0)

	jal createGame

	ori $s4, $zero, 1			# level = 1
	or $s7, $zero, $zero			# died = 0 (false)
	or $s2, $zero, $zero			# score = 0

	jal createGameObjects
	jal setGameStateOutput
	jal initgame				# initalize the game
	jal updateGameObjects

	li $v0, 100   # create and show the game screen
	li $a0, 4
	syscall

	j main1a

main1:
	jal redrawScreen   # redraw the updated game screen

main1a:
	
	li $v0, 32   # pause some milliseconds
	li $a0, 100
	syscall	

	beq $s7, $zero, main3			# if (!died) goto main3
	jal setGameoverOutput			# the Bird was hit by a pig. GAME OVER!
	jal redrawScreen   # redraw the updated game screen
	j end_main
	
main3:
	jal bird_moves				# read the user's input and the Bird moves
	jal pigs_move				# all pigs move
	jal update_state			# update the internal game states
	jal updateGameObjects

	jal is_lv_up
	beq $v0, $zero, main1			# if (!is_lv_up) goto main1
	addi $s4, $s4, 1			# increment level
	sll $s0, $s0, 1				# pig_num = pig_num * 2
	
	ori $t0, $zero, 99
	slt $t4, $t0, $s0
	beq $t4, $zero, main4
	ori $s0, $zero, 99
	
main4:	
	jal createGameObjects
	jal setGameStateOutput
	jal initgame
	jal updateGameObjects
	j main1

#-------(End main)--------------------------------------------------
end_main:

# Terminate the program
#----------------------------------------------------------------------
#li $v0, 100
#li $a0, 6
#syscall
ori $v0, $zero, 10
syscall

# Function: Setting up the game
setting:
#===================================================================


setting1:
	ori $t0, $zero, 100			# Max number of pigs
	
	la $a0, msg0				# Enter the number of Pigs you want?
	ori $v0, $zero, 4
	syscall
	
	ori $v0, $zero, 5			# cin >> pig_num
	syscall
	or $s0, $v0, $zero

	slt $t4, $t0, $s0
	bne $t4, $zero, setting3
	slti $t4, $s0, 1
	bne $t4, $zero, setting3
	j setting2

setting3:
	la $a0, msg1
	ori $v0, $zero, 4			# Invalid size
	syscall
	j setting1

setting2:
	la $a0, newline
	ori $v0, $zero, 4
	syscall

	la $a0, msg2				# Enter the seed for random number generator?
	ori $v0, $zero, 4
	syscall
	
	ori $v0, $zero, 5			# cin >> seed
	syscall
	or $s1, $v0, $zero

	ori $v0, $zero, 40    #set seed
	li $a0, 1
	or $a1, $s1, $zero
	syscall


	jr $ra

#---------------------------------------------------------------------------------------------------------------------
# Function: initalize to a new level
# Generate random positions for the Bird and the pigs
# Set the limit for sonic slingshot

initgame: 			
#===================================================================

	addi $sp, $sp, -12
	sw $s5, 8($sp)
	sw $s6, 4($sp)
	sw $ra, 0($sp)

	ori $s3, $zero, 1  #number of Slingshot is 1
	
	la $s5, pig
	sll $s6, $s0, 4
	add $s6, $s5, $s6
initgame_outer_loop:
	ori $a0, $zero, 33
	jal randnum
	
	sw $v0, 0($s5)
	
	ori $a0, $zero, 29
	jal randnum
	
	sw $v0, 4($s5)
	
	la $t2, bird
	lw $t0, 0($t2)
	lw $t1, 0($s5)
	sub $t1, $t1, $t0
	sltiu $t0, $t1, 1
	add $t3, $zero, $t0 #modified from "sub" to "add" 6/11/2014
	
	lw $t0, 4($t2)
	lw $t1, 4($s5)
	sub $t1, $t1, $t0
	sltiu $t0, $t1, 1
	add $t3, $t3, $t0 #modified from "sub" to "add" 6/11/2014
	ori $t0, $zero, 2
	beq $t3, $t0, initgame_outer_loop
	
	sw $zero, 8($s5)
	la $t7, pig
	addi $t7, $t7, -16
	
initgame_inner_loop:
	addi $t7, $t7, 16
	beq $t7, $s5, initgame_inner_loop_continue
	lw $t0, 0($t7)
	lw $t1, 0($s5)
	bne $t0, $t1, initgame_inner_loop
	lw $t0, 4($t7)
	lw $t1, 4($s5)
	bne $t0, $t1, initgame_inner_loop
	addi $s5, $s5, -16
	
initgame_inner_loop_continue:
	addi $s5, $s5, 16
	bne $s5, $s6, initgame_outer_loop

	li $v1, 0

	
	lw $s5, 8($sp)
	lw $s6, 4($sp)
	lw $ra, 0($sp)
	addi $sp, $sp, 12
	jr $ra

#---------------------------------------------------------------------------------------------------------------------
# Function: update game objects

updateGameObjects:				
#===================================================================

	addi $sp, $sp, -12
	sw $s5, 8($sp)
	sw $s6, 4($sp)
	sw $ra, 0($sp)


	la $t0, bird
	lw $a2, 0($t0)
	lw $a3, 4($t0)

	li $v0, 100	# bird's location
	li $a0, 12
	li $a1, 6				
	syscall

	li $v0, 100	# bird's image index
	li $a0, 11
	li $a1, 6
	addi $a2, $v1, 0	
	syscall

	
	
	la $s5, pig
	sll $s6, $s0, 4
	add $s6, $s6, $s5
	li $t9, 7
print2:
	lw $a2, 0($s5)
	lw $a3, 4($s5)
	li $v0, 100	# pig's location
	li $a0, 12
	addi $a1, $t9, 0				
	syscall
	
	
	lw $t1, 8($s5)
	ori $t0, $zero,1
	beq $t1, $t0, print3
	ori $t0, $zero,2
	beq $t1, $t0, print5
	
	li $v0, 100	# pig's image index
	li $a0, 11
	addi $a1, $t9, 0
	li $a2, 2	
	syscall

	j print4
	
print3:
	li $v0, 100	# pig's image index
	li $a0, 11
	addi $a1, $t9, 0
	li $a2, 3	
	syscall
	j print4

print5:
	li $v0, 100	# pig's image index
	li $a0, 11
	addi $a1, $t9, 0
	li $a2, -1	
	syscall

print4:	
	addi $t9, $t9, 1
	addi $s5, $s5, 16
	bne $s5, $s6, print2
	
	li $v0, 100	# Score number
	li $a0, 14
	li $a1, 1
	addi $a2, $s2, 0	
	syscall

	li $v0, 100	# slingshot number
	li $a0, 14
	li $a1, 3
	addi $a2, $s3, 0	
	syscall

	li $v0, 100	# level number
	li $a0, 14
	li $a1, 5
	addi $a2, $s4, 0	
	syscall

	
finish:
	lw $s5, 8($sp)
	lw $s6, 4($sp)
	lw $ra, 0($sp)
	addi $sp, $sp, 12
	
	jr $ra
	
#----------------------------------------------------------------------------------------------------------------------
# Function: set the game state's output objects

setGameStateOutput:				
#===================================================================


	li $t0, 485
	
	li $v0, 100	# Score string
	li $a0, 13
	li $a1, 0
	la $a2, msg4				
	syscall
	
	li $v0, 100	# Score string's location
	li $a0, 12
	li $a1, 0
	li $a2, 30
	move $a3, $t0				
	syscall

	li $v0, 100	# Score number
	li $a0, 14
	li $a1, 1
	addi $a2, $s2, 0	
	syscall
	
	li $v0, 100	# Score number's location
	li $a0, 12
	li $a1, 1
	li $a2, 80
	move $a3, $t0				
	syscall


	li $v0, 100	# Slingshot string
	li $a0, 13
	li $a1, 2
	la $a2, msg5				
	syscall
	
	li $v0, 100	# Slingshot string's location
	li $a0, 12
	li $a1, 2
	li $a2, 210
	move $a3, $t0				
	syscall

	li $v0, 100	# Slingshot number
	li $a0, 14
	li $a1, 3
	addi $a2, $s3, 0	
	syscall
	
	li $v0, 100	# Slingshot number's location
	li $a0, 12
	li $a1, 3
	li $a2, 300
	move $a3, $t0				
	syscall


	li $v0, 100	# level string
	li $a0, 13
	li $a1, 4
	la $a2, msg6				
	syscall
	
	li $v0, 100	# level string's location
	li $a0, 12
	li $a1, 4
	li $a2, 410
	move $a3, $t0				
	syscall

	li $v0, 100	# level number
	li $a0, 14
	li $a1, 5
	addi $a2, $s4, 0	
	syscall
	
	li $v0, 100	# level number's location
	li $a0, 12
	li $a1, 5
	li $a2, 460
	move $a3, $t0				
	syscall

	jr $ra
	
#----------------------------------------------------------------------------------------------------------------------
# Function: set the gameover output objects

setGameoverOutput:				
#===================================================================

############################
# Please add your code here#
############################

	li $v0, 100	# Set GameOverOutput
	li $a0, 13
	li $a1, 7
	la $a2, msg3
	syscall
	
	li $v0, 100	# string's location
	li $a0, 12	# ---- Set game object's location
	li $a1, 7
	li $a2, 60
	li $a3, 225				
	syscall
	
	li $v0, 100
	li $a0, 16
	li $a1, 7
	li $a2, 32	#font
	li $a3, 1	#using Bold font
	li $t0, 1	#using ltalic font	
	syscall
		
	li $v0, 100	# set color
	li $a0, 15
	li $a1, 7
	li $a2, 0xff0000 # red
	syscall
	jr $ra



#----------------------------------------------------------------------------------------------------------------------
# Function: 1 read the user's input (using getInput) and 2 handle the Bird's movement

bird_moves:
#===================================================================

############################
# Please add your code here#
############################

	addi $sp, $sp, -12
	sw $s6, 8($sp)
	sw $s7, 4($sp)
	sw $ra, 0($sp)
	
	la $s5, bird

	jal getInput

	ori $t0, $zero, 48
	beq $v0, $t0, end_main

lowerLeft:
	ori $t0, $zero, 49
	bne $v0, $t0, lower
	lw $t2, 0($s5)
	lw $t3, 4($s5)
	addi $t2, $t2, -2
	addi $t3, $t3, 2
	slti $t8, $t2, 1
	bne $t8, $zero, End_bird_move
	slti $t8, $t3, 420
	beq $t8, $zero, End_bird_move
	sw $t2, 0($s5)
	sw $t3, 4($s5)
	j check_index
	j End_bird_move
	
lower:	
	ori $t0, $zero, 50
	bne $v0, $t0, lowerRight
	lw $t3, 4($s5)
	addi $t3, $t3, 2
	slti $t8, $t3, 420
	beq $t8, $zero, End_bird_move
	sw $t3, 4($s5)
	j check_index
	j End_bird_move

lowerRight:
	ori $t0, $zero, 51
	bne $v0, $t0, middleLeft
	lw $t2, 0($s5)
	lw $t3, 4($s5)
	addi $t2, $t2, 2
	addi $t3, $t3, 2
	slti $t8, $t2, 480
	beq $t8, $zero, End_bird_move
	slti $t8, $t3, 420
	beq $t8, $zero, End_bird_move
	sw $t2, 0($s5)
	sw $t3, 4($s5)
	j check_index
	j End_bird_move

middleLeft:
	ori $t0, $zero, 52
	bne $v0, $t0, middle
	lw $t2, 0($s5)
	addi $t2, $t2, -2
	slti $t8, $t2, 1
	bne $t8, $zero, End_bird_move
	sw $t2, 0($s5)
	j check_index
	j End_bird_move
	

middle:
	ori $t0, $zero, 53
	bne $v0, $t0, middleRight
	j End_bird_move

middleRight:
	ori $t0, $zero, 54
	bne $v0, $t0, upperLeft
	lw $t2, 0($s5)
	addi $t2, $t2, 2
	slti $t8, $t2, 480
	beq $t8, $zero, End_bird_move
	sw $t2, 0($s5)
	j check_index
	j End_bird_move
	
upperLeft:
	ori $t0, $zero, 55
	bne $v0, $t0, upper
	lw $t2, 0($s5)
	lw $t3, 4($s5)
	addi $t2, $t2, -2
	addi $t3, $t3, -2
	slti $t8, $t2, 1
	bne $t8, $zero, End_bird_move
	slti $t8, $t3, 1
	bne $t8, $zero, End_bird_move
	sw $t2, 0($s5)
	sw $t3, 4($s5)
	j check_index
	j End_bird_move

upper:
	ori $t0, $zero, 56
	bne $v0, $t0, upperRight
	lw $t2, 0($s5)
	lw $t3, 4($s5)
	addi $t2, $t2, -2
	addi $t3, $t3, -2
	slti $t8, $t2, 1
	bne $t8, $zero, End_bird_move
	slti $t8, $t3, 1
	bne $t8, $zero, End_bird_move
	sw $t2, 0($s5)
	sw $t3, 4($s5)
	j check_index
	j End_bird_move	

upperRight:
	ori $t0, $zero, 57
	bne $v0, $t0, t_Rand_jump
	lw $t2, 0($s5)
	lw $t3, 4($s5)
	addi $t2, $t2, 2
	addi $t3, $t3, -2
	slti $t8, $t2, 480
	beq $t8, $zero, End_bird_move
	slti $t8, $t3, 1
	bne $t8, $zero, End_bird_move
	sw $t2, 0($s5)
	sw $t3, 4($s5)
	j check_index
	j End_bird_move

t_Rand_jump:
	ori $t0, $zero, 116
	bne $v0, $t0, r_Kill_region
new_rand:
	ori $a0, $zero, 33
	jal randnum
	add $t0, $v0, $zero	# t0 =new x-coord of bird
	slti $t5, $t0, 480
	beq $t5, $zero, new_rand
	slti $t5, $t0, 1
	bne $t5, $zero, new_rand
	
	ori $a0, $zero, 29
	jal randnum
	add $t1, $v0, $zero	# t1 = new y-coord of bird
	slti $t5, $t1, 420
	beq $t5, $zero, new_rand
	slti $t5, $t1, 1
	bne $t5, $zero, new_rand
	# store new randam coordinates
	sw $t0, 0($s5)	
	sw $t1, 4($s5)
	j End_bird_move


r_Kill_region:
	ori $t0, $zero, 114
	bne $v0, $t0, End_bird_move
	slti $t0, $s3, 1
	bne $t0, $zero, End_bird_move
	addi $s3, $s3, -1
	lw $t2, 0($s5)		#t2 == bird' x
	lw $t3, 4($s5)		#t3 == bird' y
	la $s5, pig
	sll $s6, $s0, 4
	add $s6, $s6, $s5
region_loop:	
	lw $t4, 0($s5)
	lw $t5, 4($s5)
	addi $t6, $t2, -60
	slt $t7, $t4, $t6
	bne $t7, $zero, region_next
	addi $t6, $t3, -60
	slt $t7, $t5, $t6
	bne $t7, $zero, region_next
	addi $t6, $t2, 60
	slt $t7, $t4, $t6
	beq $t7, $zero, region_next
	addi $t6, $t3, 60
	slt $t7, $t5, $t6
	beq $t7, $zero, region_next
	ori $t0, $zero, 2
	sw $t0, 8($s5)
region_next:	
	addi $s5, $s5, 16
	bne $s5, $s6, region_loop
	j End_bird_move
	

check_index:
	addi $t5, $zero, 0
	beq $v1,$zero, change_to_one
	addi $v1, $v1, -1
	lw $ra, 0($sp)
	addi $sp, $sp, 4
	jr $ra
change_to_one:
	addi $v1, $v1, 1
	lw $ra, 0($sp)
	addi $sp, $sp, 4
	jr $ra

End_bird_move:
	lw $ra, 0($sp)
	addi $sp, $sp, 4
	jr $ra
#----------------------------------------------------------------------------------------------------------------------
# Function: move the pigs

pigs_move:
#===================================================================

	addi $sp, $sp, -8
	sw $s5, 4($sp)
	sw $s6, 0($sp)

	la $t0, bird
	lw $t2, 0($t0)
	lw $t3, 4($t0)

	la $s5, pig
	sll $s6, $s0, 4
	add $s6, $s5, $s6

pigs_move_loop:
	lw $t0, 8($s5)
	bne $t0, $zero, pigs_move_continue

	lw $t4, 0($s5)
	addi $t4, $t4, -1
	slt $t0, $t4, $t2
	add $t4, $t4, $t0
	slt $t0, $t4, $t2
	add $t4, $t4, $t0
	sw $t4, 0($s5)
	
	lw $t5, 4($s5)
	addi $t5, $t5, -1
	slt $t0, $t5, $t3
	add $t5, $t5, $t0
	slt $t0, $t5, $t3
	add $t5, $t5, $t0
	sw $t5, 4($s5)

pigs_move_continue:
	addi $s5, $s5, 16
	bne $s5, $s6, pigs_move_loop
	
	lw $s5, 4($sp)
	lw $s6, 0($sp)
	addi $sp, $sp, 8
	
	jr $ra

#----------------------------------------------------------------------------------------------------------------------
# Function: updating the internal game states like score, also checking any new skull and life state of the Bird

update_state:
#===================================================================

############################
# Please add your code here#
	
	addi $sp, $sp, -4
	sw $ra, 0($sp)
#-------Check bird dead: 
	la $t2, bird
	la $s5, pig
	sll $s6, $s0, 4
	add $s6,$s6,$s5
	lw $t0, ($t2)
	lw $t1, 4($t2)
loop:
	beq $s5, $s6, exit_check_dead

	lw $t3, ($s5)
	bne $t3,$t0, update_s5
	lw $t3, 4($s5)
	bne $t3, $t1, update_s5
# check pig state == healthy ?
	lw $t3, 8($s5)
	ori $t4, $zero, 0
	bne $t3, $t4, update_s5
	addi $s7, $zero, 1
	j exit_check_dead
update_s5:
	addi $s5, $s5, 16
	j loop
exit_check_dead:

#--------------Check any pigs collide ------------------#
	la $s5, pig
	sll $s6, $s0, 4
	add $s6, $s5, $s6
	
start_outer_loop:
	la $t1, 0($s5)
outer_loop:
	addi $t1, $t1, 16
inner_loop:	
	beq $t1, $s6, update_pig_s5
	beq $t1, $s5, inner_loop_continue
	lw $t0, 0($s5)
	lw $t3, 0($t1)
	
	bne $t3, $t0, outer_loop
	lw $t0, 4($s5)
	lw $t3, 4($t1)
	bne $t3, $t0, outer_loop
	# ---- collision is here ------#
	ori $t5, $zero, 1
	sw $t5, 8($s5)
	sw $t5, 8($t1) 	# uddate the state to skull
inner_loop_continue:
	addi $t1, $t1, 16
	bne $t1, $s6, inner_loop
update_pig_s5:
	addi $s5, $s5, 16
	bne $s5, $s6, start_outer_loop
	
#--------------Undate Score -----------------------------#
	add $s2, $zero, $zero	#$s2 = score
	la $s5, pig
	sll $s6, $s0, 4
	add $s6, $s5, $s6
	addi $t1, $zero, 1
update_score_loop:
	lw $t0, 8($s5)
	bne $t0, $t1, update_score_loop_continue
	addi $s2, $s2, 10
update_score_loop_continue:
	addi $s5, $s5, 16
	bne $s5, $s6, update_score_loop	
#----------all pig is checked and score is counted ----------#
	lw $ra, 0($sp)
	addi $sp, $sp, 4
	jr $ra	

############################
	


#----------------------------------------------------------------------------------------------------------------------
# Function: check if a new level is reached	
# return $v0: 0 -- false, 1 -- true

is_lv_up:
#===================================================================

############################
# Please add your code here#

	la $s5, pig
	sll $s6, $s0, 4
	add $s6, $s5, $s6
	ori $t1, $zero, 0
lv_up_loop:		
	lw $t0, 8($s5)
	beq $t1, $t0, exit_loop

	addi $s5, $s5, 16
	bne $s5, $s6, lv_up_loop
	# All states is not healthy state #
	addi $v0, $zero, 1
	jr $ra
	
exit_loop:
	add $v0, $zero, $zero
	jr $ra 
	
############################

	
	
#----------------------------------------------------------------------------------------------------------------------
# Function: get keystroke character from keyboard
# return $v0: ASCII value of keystroke character

getInput:
#===================================================================
	addi $v0, $zero, 0

	lui $t8, 0xffff
	lw $t7, 0($t8)
	andi $t7,$t7,1
	beq $t7, $zero, getInput1
	lw $v0, 4($t8)

getInput1:	
	jr $ra

#----------------------------------------------------------------------------------------------------------------------


# Function: generate a random number and return it times 15 in $v0
# $a0 = range
randnum:
#===================================================================
	li $v0, 42
	addi $a1, $a0, 0
	li $a0, 1 
	syscall
	li $t0, 15
	mult $t0, $a0 
	mflo $v0

	jr $ra
#----------------------------------------------------------------------------------------------------------------------


## Function: create game
createGame:
#===================================================================
	li $v0, 100	
	li $a0, 1

	la $t0, width
	lw $a1, ($t0) 
	la $t0, height
	lw $a2, ($t0)

	la $a3, title
	la $t0, backgroundImg
	syscall

	li $v0, 100
	li $a0, 3
	li $a1, 4
	la $a2, images
	syscall
 
	jr $ra
#----------------------------------------------------------------------------------------------------------------------
## Function: create game objects
createGameObjects:
#===================================================================

	li $v0, 100	
	li $a0, 2
	addi $a1, $s0, 8   # besides pigs, need 8 extra game objects for the Bird and text outputs
	syscall
 
	jr $ra
#----------------------------------------------------------------------------------------------------------------------

## Function: redraw game screen
redrawScreen:
#===================================================================
	li $v0, 100   # redraw the updated game screen
	li $a0, 5
	syscall

	jr $ra
#----------------------------------------------------------------------------------------------------------------------
## Function: pause execution for X milliseconds from the specified time T (some moment ago). If the current time is not less than (T + X), pause for only 1ms.    
# $a0 = specified time T (lower 32 bits of the time returned from a previous syscalll of code 30)
# $a1 = X amount of time to pause in milliseconds 
pauseExecution:
#===================================================================
	andi $a0, $a0, 0x3fffffff
	add $t0, $a0, $a1

	li $v0, 30
	syscall
	andi $a0, $a0, 0x3fffffff

	sub $a0, $a0, $t0

	bgt $a0, $zero, positiveTime
	li $a0, 1     # pause for at least 1ms

positiveTime:

	li $v0, 32	 
	syscall

	jr $ra
#----------------------------------------------------------------------------------------------------------------------
