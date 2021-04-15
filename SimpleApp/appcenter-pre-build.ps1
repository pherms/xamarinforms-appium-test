# Running appium local server

write-host "Starting appium server"
start-job -scriptblock{appium -a 127.0.0.1 -p 4723 | out-null}

write-host "--------- Environment Variables ---------"
csc /?
write-host "--------- Environment Variables ---------"