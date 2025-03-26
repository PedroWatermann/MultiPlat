<?php 
include "conecta.php";

$id = $_GET["id"];
$nome = $_POST["nome"];
$cidade = $_POST["cidade"];
$celular = $_POST["celular"];

$sql = "UPDATE pessoas SET nome = ?, cidade = ?, celular = ? WHERE id_pessoa = ?";
$pes = $conn->prepare($sql) or die($conn->error);
if (!$pes) {
    echo $conn->error;
} else {
    $pes->bind_param("sssi", $nome, $cidade, $celular, $id);
    $pes->execute();
    $pes->close();
    echo 
    "
        <script>
            alert('Registro editado com sucesso!');
            window.location.href = 'index.php';
        </script>
    ";
}