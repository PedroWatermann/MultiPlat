<?php

include "conecta.php";

$nome = $_POST["nome"];
$cidade = $_POST["cidade"];
$celular = $_POST["celular"];

if (!isset($nome) || !isset($cidade) || !isset($celular)) {
    echo 
    "
        <script>
            alert('Preencha todos os campos!');
            window.location.href = 'index.php';
        </script>
    ";
}

$sql = "INSERT INTO pessoas(nome, cidade, celular) VALUES('$nome', '$cidade', '$celular')";

if (mysqli_query($conn, $sql)) {
    echo 
    "
        <script>
            alert('Pessoa cadastrada com sucesso!');
            window.location.href = 'index.php';
        </script>
    ";
} else {
    echo mysqli_error($conn);
}

mysqli_close($conn);