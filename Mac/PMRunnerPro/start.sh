DIR=$(cd "$(dirname "$0")"; pwd)
SEPERATOR=/
FILE=PMRunnerPro.jar

FILEPATH=$DIR$SEPERATOR$FILE

if [ `getconf LONG_BIT` = "64" ]
then
    java -Xms5g -Xmx10g -jar $FILEPATH
else
    java -Xms3g -Xmx4g -jar $FILEPATH
fi