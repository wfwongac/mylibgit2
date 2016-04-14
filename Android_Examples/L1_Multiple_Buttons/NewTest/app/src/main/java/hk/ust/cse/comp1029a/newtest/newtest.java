package hk.ust.cse.comp1029a.newtest;

import android.os.Bundle;
import android.support.v7.app.ActionBarActivity;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;


public class newtest extends ActionBarActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_newtest);

        // get a reference to goodMorning button
        Button goodMorningButton = (Button) findViewById(R.id.goodMorningButton);
        goodMorningButton.setOnClickListener(this);

        //get a reference to the goodAfternoon button
        Button goodAfternoonButton = (Button) findViewById(R.id.goodAfternoonButton);
        goodAfternoonButton.setOnClickListener(this);

        //get a reference to the goodNight button
        Button goodNightButton = (Button) findViewById(R.id.goodNightButton);
        goodNightButton.setOnClickListener(this);
    }


    @Override
    public void onClick(View v) {
        // This method is called whenever user clicks on the buttons on the screen
        // Recognize which button has been clicked and take appropriate action

        TextView textMessage = (TextView) findViewById(R.id.textMessage);
        switch (v.getId()){
            case R.id.goodMorningButton:
                textMessage.setText("Good Morning!");
                break;
            case R.id.goodAfternoonButton:
                textMessage.setText("Good Afternoon!");
                break;
            case R.id.goodNightButton:
                textMessage.setText("Good Night!");
                break;
            default:
                break;
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_newtest, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }
}
