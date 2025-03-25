<?php

include "conecta.php";

$pessoas = mysqli_query($conn,"SELECT * FROM pessoas");
$registros = mysqli_num_rows($pessoas);
if ($registros > 0) {
    echo 
    "
        <table class='table table-hover'>
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Nome</th>
                    <th>Cidade</th>
                    <th>Celular</th>
                    <th>Ações</th>
                </tr>
            </thead>
    ";
    while ($registro = $pessoas->fetch_array()) {
        echo 
        "
        <tbody>
                <tr>
                    <td>" . $registro['id'] . "</td>
                    <td>" . $registro['nome'] . "</td>
                    <td>" . $registro['cidade'] . "</td>
                    <td>" . $registro['celular'] . "</td>
                    <td><a href='editar.php?id=$id'>Editar</a> | <a href='excluir.php?id=$id'>Excluir</a></td>
                </tr>
        ";
    }
    echo 
    "
        </tbody>
        </table>
    ";
} else {
    echo "<center><h3>Nenhuma pessoa cadastrada!</h3></center>";
}
echo "Total de pessoas cadastradas: ".$registros;