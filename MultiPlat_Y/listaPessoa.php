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
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
        ";
    }
    echo 
    "
        </tbody>
        </table>
    ";
}