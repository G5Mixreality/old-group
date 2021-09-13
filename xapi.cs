
//Must include these 3
//To use TinCan, you might need to add the dependencies.
//If you have MSVS, open the solution explorer and
//right click on dependencies. Then click
//"Manage NuGet Packages". This will bring up a new
//window. On the "Browse" tab, search for "TinCan".
//Install the package and it will clear all the 
//errors related to TinCan. This is required to
//communicate with educational servers. 
using System;
using TinCan;
using TinCan.LRSResponses;

namespace xApidll
{
    public class xapi
    {
        //You can call this dll function like you would any other function. Think of
        //DLLs like a combined C++ header+function file. It works the same. 
        //Ill explain what can be broken appart to make multiple functions that you 
        //can insert individually as you need.
        public void xAPI(string newVerb, string activityId, string activityName, string activityDescription)
        {
            //These are your variables. Above, in the function definition, you are
            //required to pass all 4 into this function, however, it could be broken
            //into 4 functions: one to assign the actor, one to assign the verb, 
            //one to assign the activity id, name and description, and one to send it
            //all to the server. However, this is not advised since you would need
            //to have somewhere to temporarily store the variables, such as an output 
            //file. This complicates things, but I will still mark off what needs to be
            //in each function if you need to go that route.

            string verbName = newVerb; //Need to use verb in the verb function.
            
            //These three are needed for the activity function.
            string idName = activityId;
            string actName = activityName;
            string actDescript = activityDescription;

            //This is our connection to the server. This needs to be placed near the beginning of any
            //functions that are going to send information to the server. It can be used
            //in all of the individual functions if you want to send individual information.
            var lrs = new RemoteLRS(
                "https://tbuzakixapi.lrs.io:443/xapi/",
                "Admin",
                "Admin1"
            );


            //This is the actor information. This is the User's Name.
            //I currently have it set to "test" since I do not know
            //if you have a way to prompt the user to enter their name.
            //If you have a way to prompt the user, you can assign the user
            //input on the line "actor.name = "test";" changing
            //"test" to whatever variable you used to gather user
            //input.
            var actor = new Agent();
            actor.mbox = "mailto:tbuzaki@gmail.com";
            actor.name = "test";

            //This is used to set the verb. It explains what the user did. 
            //For example, a valid verb would be "Completed" or "Failed".
            //Above, we set verbName to equal one of the passed values.
            //Use the designations above to assign whatever value you want
            //to the verb. 
            var verb = new Verb();
            verb.id = new Uri("https://tbuzakixapi.lrs.io:443/xapi/");
            verb.display = new LanguageMap();
            verb.display.Add("en-US", verbName);


            //This is used to set the activity descriptions. 
            //Things such as activity id, activity name, and
            //activity description go here. An example of those
            //three values would be: "1", "ExtinguishFire", "This 
            //activity has the user extinguish a fire."
            //Everything is assigned using the lines we marked off
            //above. 
            var activity = new Activity();
            activity.id = idName;
            ActivityDefinition activityDefinition = new ActivityDefinition();
            activityDefinition.description = new LanguageMap();
            activityDefinition.name = new LanguageMap();
            activityDefinition.name.Add("en-US", (actName));
            activityDefinition.description.Add("en-US", (actDescript));
            activity.definition = activityDefinition;


            //This is where we prepare our output to the server.
            //The server only accepts complete statements, so it
            //NEEDS an actor, a verb, and an activity. Statements
            //are essentially like sentences, if it does not have 
            //all 3, it won't make sense and will throw errors.
            var statement = new Statement();
            statement.actor = actor;
            statement.verb = verb;
            statement.target = activity;

            //This pushes our statement to the server.
            //This must be at the end of any functions you 
            //intend to send statements to the server.
            //You will most likely need to combine the above 
            //statement lines with this statement push command
            //in every function you output to the server with.
            StatementLRSResponse lrsResponse = lrs.SaveStatement(statement);

        }
    }
}
