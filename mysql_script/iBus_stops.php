<?php
include "connect_to_db.php";

$string = file_get_contents("./AllStopsInTW.json");
// JSON source : http://ptx.transportdata.tw/MOTC/v2/Bus/Stop/InterCity?$format=JSON


$json_a = json_decode($string, true);

foreach($json_a as $index => $c ){
	$StopUID = $c["StopUID"];
	$StopID = $c["StopID"];
	$StopName = $c["StopName"]["Zh_tw"];
	$StopName_en = $c["StopName"]["En"];
	$LAT = $c["StopPosition"]["PositionLat"];
	$LON = $c["StopPosition"]["PositionLon"];
	$StopAddress = $c["StopAddress"];


	$sql = "INSERT INTO bus_stops ( StopUID , StopID , StopName , StopName_en , StopAddress , LON , LAT) VALUES ('$StopUID' , '$StopID' , '$StopName' , '$StopName_en' , '$StopAddress' , '$LON' , '$LAT');";
	
	mysqli_query($conn , $sql);
}
	mysqli_close($conn);
?>
