<?php
	$con = mysqli_connect("localhost","root","root","monedas");

// Check that connection happened
	if(mysqli_connect_error())
	{
		echo "1: Connection Failed";													
		exit();
	}



// Chupar la data de la base;
	$sql ="SELECT * FROM scoreboard ORDER BY scoreboard.SCORE DESC";

$result = mysqli_query($con, $sql) or die("2: Top score query failed");

    for($i = 0; $i < 5; $i++)
    {
        $row = mysqli_fetch_array($result);
        echo $row["UserName"] . "\t" . $row["SCORE"]. "\t";
    }
	
?>
