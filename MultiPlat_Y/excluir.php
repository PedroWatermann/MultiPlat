<?php 

include 'conecta.php';

$id = $_GET["id"];

$sql = "DELETE FROM pessoas WHERE id_pessoa = $id";
if (mysqli_query($conn, $sql)) {
    echo 
    "
        <script>
            alert('Registro excluído com sucesso!');
            window.location.href = 'index.php';
        </script>
    ";
} else {
    echo mysqli_error($conn);
}

mysqli_close($conn);