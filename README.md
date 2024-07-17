This is a 2D side scroller game. Please support us in making this cool thing :D

To make this repo work you must manually insert the firebase modules as well as ad mob SDK

please use Firebase_Auth, Firebase_Database, Firebase_Analytiscs
https://firebase.google.com/docs/unity/setup?hl=en&authuser=0&_gl=1*1yn3v3g*_ga*ODQyMjMzMzg0LjE3MDI0MTE3Njg.*_ga_CW55HF8NVT*MTcyMTA4MDY2MC42Ny4xLjE3MjEwODA2NjkuNTEuMC4w#add-sdks

for ad mobs please use this instruction sheet
https://developers.google.com/admob/unity/quick-start



When having failed to find frameworks for Unity to xcode build we need to use cocoapods and force update or force install certain things 
run this command if having build errors in Xcode "arc -86_64 pod install"
NOTE: This can take a long time for it to complete so be patient!!!
This will 
1. analyze the dependencies, 
2. download dependencies
3. Generatoings pods project
4. Intergrating client project
"POD installtion complete! there are {} dependecies from the Podfile and {} total pods installed
