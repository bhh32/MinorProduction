// Drag the cutscenes prefab into the Hierarchy to add the models and 
// animations. Use the script I made called RodentDeath in place of your DestroyRodent
// on the rodent despawner. Feel free to change the RodentDeath script, I had a short time
// to make it and I am expecting bugs. It will be commented on to explain how it works.
// 
// The working timeline is called RodentCutscene
//
// In order to understand the next part you will need to have read the RodentDeath script
// 
// There needs to be a check to see if the timeline has finished playing through,
// and if it has it needs to reset the objects to INACTIVE and ACTIVE respectivly.