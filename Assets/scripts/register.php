<?php
	$con = mysqli_connect("localhost","root","root","monedas");

// Check that connection happened
	if(mysqli_connect_error())
	{
		echo "1: Connection Failed";													// Error code #1 = Error de coneccion.
		exit();
	}

// Variables
	$username = $_POST["Username"];
	$score = $_POST["Score"];


// Add user to table
	$score_query = "INSERT INTO scoreboard VALUES (NULL, '" . $username . "','" . $score . "');";
	echo $score_query;
    $result = mysqli_query($con, $score_query) or die("4: Insert score query failed");		// Error code #4 = Falló la suibida de los datos.

	echo("1");
?>
