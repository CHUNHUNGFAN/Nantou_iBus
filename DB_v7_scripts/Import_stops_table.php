<?php

	class oldDB extends SQLite3 {
	  function __construct() {
		 $this->open('ibus_v6.db3');
	  }
	}
	$db = new oldDB();
	if(!$db) {
	  echo $db->lastErrorMsg();
	} else {
	  echo "Opened v6 database successfully\n";
	}

	class newDB extends SQLite3 {
	  function __construct() {
		 $this->open('ibus_v7.db3');
	  }
	}
	$newdb = new newDB();
	if(!$newdb) {
	  echo $newdb->lastErrorMsg();
	} else {
	  echo "Opened v7 database successfully\n";
	}
        $sql_create =<<<EOF
		CREATE TABLE `bus_stops` (
		`StopUID` TEXT NOT NULL,
		`StopID` TEXT NOT NULL,
		`StopName` TEXT NOT NULL,
		`StopName_en` TEXT,
		`StopAddress` TEXT,
		`LON` REAL NOT NULL,
		`LAT` REAL NOT NULL
                 ) 
EOF;
       
	$ret_create = $newdb->exec($sql_create);         
	if(!$ret_create){           
		echo $db->lastErrorMsg();
	} else {
		echo "Table created successfully\n";
	}


	$list1 =<<<EOF
		SELECT * FROM bus_stops;
EOF;
	$list1_rst = $db->query($list1);
	while( $row = $list1_rst->fetchArray(SQLITE3_ASSOC) ){
		$StopUID = $row['StopUID'];
		$StopID = $row['StopID'];
		$StopName = $row['StopName'];
		$StopName_en = $row['StopName_en'];
		$StopAddress = $row['StopAddress'];
		$LON = $row['LON'];
		$LAT = $row['LAT'];		
	
		$insert_newdb =<<<EOF
			INSERT INTO bus_stops (StopUID, StopID, StopName, StopName_en, StopAddress, LON, LAT) VALUES ('$StopUID', '$StopID', '$StopName', '$StopName_en', '$StopAddress', '$LON', '$LAT');
EOF;
					

		$newdb->query($insert_newdb);
	}
	
	$db->close();
	$newdb->close();
?>
