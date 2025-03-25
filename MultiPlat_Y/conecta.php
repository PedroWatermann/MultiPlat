<?php
$conn = mysqli_connect("sql.freedb.tech", "freedb_PedWat", 'k8PT4G&Dt?kb$k2', "freedb_dbMultiPlat");
if (!$conn) {
    echo("Erro: ". mysqli_connect_error());
}