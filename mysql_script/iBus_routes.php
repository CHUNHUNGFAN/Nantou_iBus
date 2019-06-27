<?php

include "connect_to_db.php";


$string = file_get_contents("./AllRoutesInTW.json"); 
//JSON source : http://ptx.transportdata.tw/MOTC/v2/Bus/Route/InterCity?$format=JSON
$json_a = json_decode($string, true);

foreach( $json_a as $index => $c ){
	$RouteUID = $c["RouteUID"];
	$RouteID = $c["RouteID"];

	foreach( $c["SubRoutes"] as $i => $sub ){
		$SubRouteUID = $sub["SubRouteUID"];
		$SubRouteID = $sub["SubRouteID"];
		$SubRouteName = $sub["SubRouteName"]["Zh_tw"];
		$SubRouteName_en = $sub["SubRouteName"]["En"];
		$Headsign = $sub["Headsign"];
		$Direction = $sub["Direction"];
		$sql = "INSERT INTO bus_routes ( RouteUID , RouteID , SubRouteUID , SubRouteID  , SubRouteName , SubRouteName_en , Headsign , Direction ) VALUES ('$RouteUID' , '$RouteID' , '$SubRouteUID' , '$SubRouteID' , '$SubRouteName' , '$SubRouteName_en' , '$Headsign' , '$Direction');";
		mysqli_query($conn , $sql);
	}

}

mysqli_close($conn);
?>
