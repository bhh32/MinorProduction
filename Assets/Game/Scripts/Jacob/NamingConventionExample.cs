using System.Collections;
using UnityEngine;

public class NamingConventionExample : MonoBehaviour
{
    /** Written to show the naming conventions for the project. **/

    /** The biggest thing is to comment the shit out of your code
     *  just in case someone else needs to read it. The following
     *  naming conventions will help a lot, but do not stand in
     *  for comments. Also, variable names HAVE to be meaningful.
     *  For example, if you have something that is the child of something else
     *  please do not call it baby. That is extremely general, and 
     *  doesn't get the full point across. Do something like:
     *  
     *  GameObject newPistol = Instantiate(pistolPrefab, hand.transform.position, Quaternion.Identity);
     *  newPistol.transform.parent = hand.transform;
     *  
     *  The above is extremely descriptive in what you're meaning
     *  to happen, and will help out in understanding if someone
     *  needs to help debug something that may be going wrong. Even
     *  if it's not with that particular thing because they know
     *  that it doesn't have anything to do with your current problem.
     **/

    /* If nothing besides this class needs to touch a variable please
     * set it as private explicitly or just don't mark it at all. You
     * can use [SerializeField] if you need to access it in the inspector
     * as in the following examples. 
     */
    [SerializeField] private GameObject player;
    [SerializeField] float speed;

    /* If you need other scripts to get the value of
     * a variable but never set it, use a get and set
     * property modifier as in the following examples. 
     */
    public float armorMultiplier { get; private set; }
    public float health { get; private set; }
    /* Enums should be all caps as in the following examples. 
     * The reason for this is that it lets us know just by looking
     * that they are enums and not something else.
     */
    enum ExampleStates
    { IDLE, WALK, RUN, JUMP, FLY, ATTACK, EMPTY, ERROR };

    enum ExampleConditionStates
    { WIN, LOSE, PLAYING, ERROR };

    /* Variables should start with a lowercase letter, and 
     * every beginning of a new word after should start with
     * an uppercase letter (or number) as the above and following
     * examples show (this is commonly known as pascal case
     * and is the standard way of doing things in C# development). 
     * The reason for this is to quickly identify if something is a 
     * variable as only variables will have this particular naming convention.
     */
    string exampleVariableString = "This is an example of the variable naming convention!";

    /* Methods (or functions) will be the beginning of words all uppercase 
     * (this is known as camelcase and is the standard way of doing things
     * in C# development). IEnumerators (for Coroutines) will be done as if
     * they are Methods (or functions).
     */
    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    IEnumerator TestCoroutine()
    {
        float count = 0f;

        while (count < 10f)
        {
            count++;

            // Easy way to do text without having to concatnate everything.
            // This way can also be used to format timers to specific decimal
            // places if needed.
            Debug.Log(string.Format("Count: {0}", count.ToString()));

            yield return new WaitForSeconds(1f);
        }
    }
}
