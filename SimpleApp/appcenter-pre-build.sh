#!/bin/bash

# Start appium server
echo "Starting appium server"
appium -a 127.0.0.1 -p 4723 &>/dev/null &