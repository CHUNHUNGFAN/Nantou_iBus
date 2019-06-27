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
		CREATE TABLE `bus_routes` (
			`RouteUID`	TEXT NOT NULL,
			`RouteID`	TEXT NOT NULL,
			`SubRouteUID`	TEXT NOT NULL,
			`SubRouteID`	NUMERIC NOT NULL,
			`SubRouteName`	TEXT NOT NULL,
			`SubRouteName_en`	TEXT,
			`Headsign`	TEXT NOT NULL,
			`Direction`	INTEGER NOT NULL
		)

EOF;
	$ret_create = $db->exec($sql_create);
	if(!$ret_create){
	  echo $db->lastErrorMsg();
	} else {
	  echo "Table created successfully\n";
	}


	$msql_list =<<<EOF
		SELECT RouteUID, RouteID, SubRouteUID, SubRouteID, SubRouteName, SubRouteName_en, Headsign, Direction FROM bus_routes;
EOF;

	$mrst_list = mysqli_query( $conn, $msql_list);
	while( $row = mysqli_fetch_array($mrst_list) ){
	    $RouteUID = $row['RouteUID'];
		$RouteID = $row['RouteID'];
		$SubRouteUID = $row['SubRouteUID'];
		$SubRouteID = $row['SubRouteID'];
		$SubRouteName = $row['SubRouteName'];
		$SubRouteName_en = $row['SubRouteName_en'];
		$Headsign = $row['Headsign'];
		$Direction = $row['Direction'];

		$sql_insert =<<<EOF
			INSERT INTO bus_routes (RouteUID, RouteID, SubRouteUID, SubRouteID, SubRouteName, SubRouteName_en, Headsign, Direction ) VALUES ('$RouteUID', '$RouteID', '$SubRouteUID', '$SubRouteID', '$SubRouteName', '$SubRouteName_en', '$Headsign', '$Direction');
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
