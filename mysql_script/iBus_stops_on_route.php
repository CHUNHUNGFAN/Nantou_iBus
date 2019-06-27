<?php

include "connect_to_db.php";


//$string = file_get_contents("StopsOnRoute.json");

$sql_stopID = "SELECT * FROM bus_routes GROUP BY RouteID;";
$result_id = mysqli_query($conn, $sql_stopID);

while( $row = mysqli_fetch_array($result_id) ){
	$id = $row["RouteID"];
	$string = file_get_contents("http://ptx.transportdata.tw/MOTC/v2/Bus/StopOfRoute/InterCity/$id?\$format=JSON");


	$json_a = json_decode($string, true);

	foreach( $json_a as $index => $c ){
		$RouteUID = $c["RouteUID"];
		$SubRouteUID = $c["SubRouteUID"];
		$Direction = $c["Direction"];

		foreach( $c["Stops"] as $i => $sub ){
			$StopUID = $sub["StopUID"];
			$sql = "INSERT INTO bus_stops_on_route ( RouteUID , SubRouteUID , Direction , StopUID) VALUES ('$RouteUID' , '$SubRouteUID' , '$Direction' , '$StopUID');";
			mysqli_query($conn , $sql);
		}

	}

}
mysqli_close($conn);
?>
