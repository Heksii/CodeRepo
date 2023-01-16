<?php
if (!isset($_SESSION)) {
    session_start();
}

if ($_SERVER["REQUEST_METHOD"] == "POST") {
    $_SESSION["user"] = $_POST["username"];

    header("Location: loginLanding.php");
    die;
}
?>

<!DOCTYPE html>
<?php include('includes/head.php'); ?>

<body>
    <main class="index-main">
        <img src="img/logo.png">
        <form action="<?= htmlspecialchars($_SERVER["PHP_SELF"]) ?>" method="post">
            <div>
                <label for="username">Plejefamilie:</label>
                <input type="text" name="username" required>
            </div>

            <div>
                <label for="password">Adgangskode:</label>
                <input type="password" name="password" required>
            </div>

            <input type="submit" value="Log ind">
        </form>
    </main>
</body>


