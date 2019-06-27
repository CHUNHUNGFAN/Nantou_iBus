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
		CREATE TABLE `bus_stops_on_route` (
			`RouteUID` TEXT NOT NULL,
			`SubRouteUID` TEXT NOT NULL,
			`Direction` INTEGER NOT NULL,
			`StopID` TEXT NOT NULL,
			`StopSequence` INTEGER NOT NULL
                 )
EOF;
	$ret_create = $newdb->exec($sql_create);
	if(!$ret_create){
	  echo $db->lastErrorMsg();
	} else {
	  echo "Table created successfully\n";
	}


	$subroute_list =<<<EOF
		SELECT * FROM bus_stops_on_route GROUP BY SubRouteUID;
EOF;
	$subroute_list_rst = $db->query($subroute_list);
	$count = 0;
	while( $row = $subroute_list_rst->fetchArray(SQLITE3_ASSOC) ){
		$RouteUID = $row['RouteUID'];
		$SubRouteUID = $row['SubRouteUID'];
		$Direction = $row['Direction'];
		$StopID = $row['StopID'];
		$data = file_get_contents("http://ptx.transportdata.tw/MOTC/v2/Bus/StopOfRoute/InterCity?\$filter=SubRouteUID%20eq%20'$SubRouteUID'&\$format=JSON");
		$json_a = json_decode($data, true);   
		foreach( $json_a as $index => $c ){
			foreach( $c["Stops"] as $i => $sub ){      
				$StopName = $sub['StopName']['Zh_tw'];
				$StopSequence = $sub['StopSequence'];
				$stopname_list =<<<EOF
					SELECT * FROM bus_stops WHERE StopName = '$StopName' GROUP BY StopName;
EOF;
				$stopname_list_rst = $db->query($stopname_list);
				$row_stopname = $stopname_list_rst->fetchArray(SQLITE3_ASSOC);
				$StopID = $row_stopname['StopID'];
				$insert_newdb =<<<EOF
					INSERT INTO bus_stops_on_route (RouteUID, SubRouteUID, Direction, StopID, StopSequence) VALUES ('$RouteUID', '$SubRouteUID', '$Direction', '$StopID', '$StopSequence');
EOF;
					

				$newdb->query($insert_newdb);
				$count++;
				echo $count."\n";
			}
		}
	}
	
	$db->close();
	$newdb->close();
?>
