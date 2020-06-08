@echo off

cd C:\Users\norge\Downloads

start java -Dwebdriver.chrome.driver="C:\Users\norge\source\repos\ParallelSpecflow\ParallelSpecflowTest\bin\Debug\netcoreapp3.1\chromedriver.exe" -jar selenium-server-standalone-3.141.59.jar -role webdriver -hub http://192.168.0.9:4444/grid/register/ -port 5555

