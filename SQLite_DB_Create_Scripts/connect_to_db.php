<?php
$servername = "ms14.voip.edu.tw";
$username = "ibus";
$password = "ibus";
$dbname = "ibus";
//connect database
$conn = mysqli_connect($servername, $username, $password) or die ("could not connect to mysql");
//echo error message
if (mysqli_connect_errno($conn)){
        echo "Failed to connect to MySQL: " . mysqli_connect_error();
}

mysqli_select_db($conn, "ibus") or die ("no database");


mysqli_query($conn,"set names utf8");  //Chinese
?>

