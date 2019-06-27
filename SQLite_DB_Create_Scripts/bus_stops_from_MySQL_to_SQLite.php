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
		CREATE TABLE `bus_stops` (
			`StopUID`	TEXT NOT NULL,
			`StopID`	TEXT NOT NULL,
			`StopName`	TEXT NOT NULL,
			`StopName_en`	TEXT,
			`StopAddress`	TEXT,
			`LON`	REAL NOT NULL,
			`LAT`	REAL
		)
EOF;
	$ret_create = $db->exec($sql_create);
	if(!$ret_create){
	  echo $db->lastErrorMsg();
	} else {
	  echo "Table created successfully\n";
	}


	$msql_list =<<<EOF
		SELECT StopUID, StopID, StopName, StopName_en,StopAddress, LON, LAT FROM bus_stops;
EOF;

	$mrst_list = mysqli_query( $conn, $msql_list);
	while( $row = mysqli_fetch_array($mrst_list) ){
		$StopUID = $row['StopUID'];
		$StopID = $row['StopID'];
		$StopName = $row['StopName'];
		$StopName_en = $row['StopName_en'];
		$StopAddress = $row['StopAddress'];
		$LON = $row['LON'];
		$LAT = $row['LAT'];


		$sql_insert =<<<EOF
			INSERT INTO bus_stops (StopUID, StopID, StopName, StopName_en,StopAddress, LON, LAT ) VALUES ('$StopUID', '$StopID', '$StopName', '$StopName_en', '$StopAddress', '$LON', '$LAT');
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
