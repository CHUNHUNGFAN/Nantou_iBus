<?php
	include "connect_to_db.php";

	class MyDB extends SQLite3 {
	  function __construct() {
		 $this->open('ibus_v3.db3');
	  }
	}
	$db = new MyDB();
	if(!$db) {
	  echo $db->lastErrorMsg();
	} else {
	  echo "Opened database successfully\n";
	}

	$sql_create =<<<EOF
		CREATE TABLE `bus_stops_on_route` (
			`RouteUID`	TEXT NOT NULL,
			`SubRouteUID`	TEXT NOT NULL,
			`Direction`	INTEGER NOT NULL,
			`StopID`	TEXT NOT NULL
		)
EOF;
	$ret_create = $db->exec($sql_create);
	if(!$ret_create){
	  echo $db->lastErrorMsg();
	} else {
	  echo "Table created successfully\n";
	}


	$msql_list =<<<EOF
		SELECT RouteUID , SubRouteUID, Direction, StopID FROM bus_stops_on_route;
EOF;

	$mrst_list = mysqli_query( $conn, $msql_list);
	while( $row = mysqli_fetch_array($mrst_list) ){
		$RouteUID = $row['RouteUID'];
		$SubRouteUID = $row['SubRouteUID'];
		$Direction = $row['Direction'];
		$StopID = $row['StopID'];


		$sql_insert =<<<EOF
			INSERT INTO bus_stops_on_route (RouteUID, SubRouteUID, Direction, StopID) VALUES ('$RouteUID', '$SubRouteUID','$Direction','$StopID' )

EOF;
		$ret_insert = $db->exec($sql_insert);
		if(!$ret_insert) {
			echo $db->lastErrorMsg();
		} else {
			echo "Records created successfully\n";
		}

	}
	
	mysqli_close($conn);
	$db->close();
?>
