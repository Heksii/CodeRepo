<?php
if (!isset($_SESSION)) {
    session_start();
}
?>

<!DOCTYPE html>
<?php include('includes/head.php'); ?>

<body>
    <?php include('includes/header.php'); ?>

    <main class="list-main">
        <article>   
            
        </article>
        <article>   
            <div class="links-section">
                <a href="#">Checkliste for plejefamilier</a>
                <a href="#">Se/ret mine oplysninger / Skift kode</a>
                <a href="#">Tilføj en kat</a>
                <a href="#">Bestil varer</a>
                <a href="#">Medicin</a>
            </div>
            <div class="links-section">
                <a href="#">Checkliste for plejefamilier</a>
                <a href="#">Se/ret mine oplysninger / Skift kode</a>
                <a href="#">Tilføj en kat</a>
                <a href="#">Bestil varer</a>
                <a href="#">Medicin</a>
            </div>
            <div class="links-section"></div>
                <a href="logout.php">Log ud</a>
                
                <form action="<?= htmlspecialchars($_SERVER["PHP_SELF"]) ?>" method="post">
                    <label for="search"><strong>Søgning</strong></label>
                    <p>(navn, øremærke, chip eller journalNr.)</p>
                    <input type="text" name="search">
                    <input type="submit" value="Søg">
                </form>
            </div>
        </article>
    </main>
</body>