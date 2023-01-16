<?php
if (!isset($_SESSION)) {
    session_start();
}

unset($_SESSION);
header("Location: index.php");
die;
?>