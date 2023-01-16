<?php
if (!isset($_SESSION)) {
    session_start();
}
?>

<header>
    <div>
        <img src="img/logo.png">
    </div>
    <div>
        <strong><?= $_SESSION["user"] ?? "Ikke logget ind" ?></strong>
    </div>
</header>