function connect($db) {
    $baseUrl = "../"
    $dbFile = "database.db" #if ($db -eq "prod") { "ProductDB.db" } else { "TestProductDB.db" }
    $env:SCRIPT_DATABASE_URL = $baseUrl + $dbFile
}

function kiosk($query) {
    sqlite3 $env:SCRIPT_DATABASE_URL $query
}

# function local:loading($percent) {
#     [Console]::OutputEncoding = [System.Text.Encoding]::UTF8
#     $barLength = 40
#     $filled = [math]::Round($Percent / 100 * $barLength)
#     $percent = [math]::Round($Percent)
#     $empty = $barLength - $filled 

#     $bar = ("|" * $filled) + ("." * $empty) + "$percent`%"

#     Write-Host -NoNewline "`r$bar"
# }

$script:operations = 0
$script:total = 902
function local:autoloading {
    $script:operations++
    loading (100 * $script:operations / $script:total)
}

function local:insert($table, $values) {
    $query = "insert into $table values "
    for ($i = 0; $i -lt $values.Count; $i++) {
        $formattedValues = $values[$i] | % {
            if ($_ -eq $null) { "NULL" }
            elseif ($_ -is [string]) { "'$_'" }
            elseif ($_ -is [double] -or $_ -is [float]) { $_.ToString([System.Globalization.CultureInfo]::InvariantCulture) }
            else { $_ }
        }
        $parameters = $formattedValues -join ", "
        $query += "($parameters, datetime('now', 'localtime'), datetime('now', 'localtime'), NULL)"
        if ($i -lt $values.Count - 1) {
            $query += ", "
        }
    }
    # Write-Output $query
    kiosk $query

    # autoloading
}

function local:delete($table) {
    kiosk "delete from $table"
    # autoloading
}

connect $args[0]

delete "tb_cart"
delete "tb_cart_item"
delete "tb_cart_item_ingredient"
delete "tb_combination"
delete "tb_ingredient"
delete "tb_order"
delete "tb_price_history_ingredient"
delete "tb_price_history_variant"
delete "tb_service"
delete "tb_variant"
delete "tb_variant_ingredient"


$default_image = "https://image.com"

#==SERVICE============================================================================================
$services = New-Object System.Collections.Generic.List[object]

#              ID                                       NAME            IMAGE   AVAILABLE     SERVICE_ID
$services.Add(@("00000000-0000-0000-0000-000000000001", "Pastel",       $default_image,     1))
$services.Add(@("00000000-0000-0000-0000-000000000002", "Refrigerante", $default_image,     1))
$services.Add(@("00000000-0000-0000-0000-000000000003", "Capivara",     $default_image,     1))
$services.Add(@("00000000-0000-0000-0000-000000000004", "Churros",      $default_image,     1))

#===INSERT
insert "tb_service" $services



#==VARIANT============================================================================================
$variant = New-Object System.Collections.Generic.List[object]
#              ID                                      NAME         IMAGE            INGREDIENTS   SURPASS     AVAILABLE     SERVICE_ID
#======PASTEL=====================
$variant.Add(@("00000000-0000-0000-0000-000000000001", "Medio",     $default_image,  2,            1,          1,            "00000000-0000-0000-0000-000000000001"))
#======REFRIGERANTE===============
$variant.Add(@("00000000-0000-0000-0000-000000000002", "Lata",      $default_image,  1,            1,          1,            "00000000-0000-0000-0000-000000000002"))
$variant.Add(@("00000000-0000-0000-0000-000000000003", "600mL",     $default_image,  1,            1,          1,            "00000000-0000-0000-0000-000000000002"))
$variant.Add(@("00000000-0000-0000-0000-000000000004", "2L",        $default_image,  1,            1,          1,            "00000000-0000-0000-0000-000000000002"))
#======CAPIVARA===================
$variant.Add(@("00000000-0000-0000-0000-000000000005", "Pequeno",   $default_image,  1,            1,          1,            "00000000-0000-0000-0000-000000000003"))
$variant.Add(@("00000000-0000-0000-0000-000000000006", "Medio",     $default_image,  2,            1,          1,            "00000000-0000-0000-0000-000000000003"))
$variant.Add(@("00000000-0000-0000-0000-000000000007", "Grande",    $default_image,  3,            1,          1,            "00000000-0000-0000-0000-000000000003"))
#======CHURROS====================
$variant.Add(@("00000000-0000-0000-0000-000000000008", "Medio",     $default_image,  1,            1,          1,            "00000000-0000-0000-0000-000000000004"))

#===INSERT
insert "tb_variant" $variant



#==INGREDIENT============================================================================================
$ingredient = New-Object System.Collections.Generic.List[object]
#                 ID                                        NAME             QUANTITY   AVAILABLE   SERVICE_ID
#======PASTEL=====================
$ingredient.Add(@("00000000-0000-0000-0000-000000000001",   "Carne",         $null,     1,          "00000000-0000-0000-0000-000000000001"))
$ingredient.Add(@("00000000-0000-0000-0000-000000000002",   "Queijo",        $null,     1,          "00000000-0000-0000-0000-000000000001"))
$ingredient.Add(@("00000000-0000-0000-0000-000000000003",   "Pizza",         $null,     1,          "00000000-0000-0000-0000-000000000001"))
$ingredient.Add(@("00000000-0000-0000-0000-000000000004",   "Chocolate",     $null,     1,          "00000000-0000-0000-0000-000000000001"))
#======REFRIGERANTE===============
$ingredient.Add(@("00000000-0000-0000-0000-000000000005",   "Coca-Cola",     $null,     1,          "00000000-0000-0000-0000-000000000002"))
$ingredient.Add(@("00000000-0000-0000-0000-000000000006",   "Pepsi",         $null,     1,          "00000000-0000-0000-0000-000000000002"))
$ingredient.Add(@("00000000-0000-0000-0000-000000000007",   "Fanta Uva",     $null,     1,          "00000000-0000-0000-0000-000000000002"))
$ingredient.Add(@("00000000-0000-0000-0000-000000000008",   "Fanta Laranja", $null,     1,          "00000000-0000-0000-0000-000000000002"))
#======CAPIVARA===================
$ingredient.Add(@("00000000-0000-0000-0000-000000000009",   "Carne",         $null,     1,          "00000000-0000-0000-0000-000000000003"))
$ingredient.Add(@("00000000-0000-0000-0000-00000000000a",   "Queijo",        $null,     1,          "00000000-0000-0000-0000-000000000003"))
$ingredient.Add(@("00000000-0000-0000-0000-00000000000b",   "Pizza",         $null,     1,          "00000000-0000-0000-0000-000000000003"))
$ingredient.Add(@("00000000-0000-0000-0000-00000000000c",   "Chocolate",     $null,     1,          "00000000-0000-0000-0000-000000000003"))
#======CHURROS====================
$ingredient.Add(@("00000000-0000-0000-0000-00000000000d",   "Chocolate",     $null,     1,          "00000000-0000-0000-0000-000000000004"))
$ingredient.Add(@("00000000-0000-0000-0000-00000000000e",   "Avelã",         $null,     1,          "00000000-0000-0000-0000-000000000004"))
$ingredient.Add(@("00000000-0000-0000-0000-00000000000f",   "Doce de leite", $null,     1,          "00000000-0000-0000-0000-000000000004"))

#===INSERT
insert "tb_ingredient" $ingredient



#==PRICE_HISTORY_VARIANT===================================================================================
$price_history_variant = New-Object System.Collections.Generic.List[object]
#                               ID                                     PRICE   VARIANT_ID
#======PASTEL=====================
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000001",   10.0,   "00000000-0000-0000-0000-000000000001")) # MEDIO
#======REFRIGERANTE===============
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000002",   6.0,    "00000000-0000-0000-0000-000000000002")) # LATA
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000003",   12.0,   "00000000-0000-0000-0000-000000000003")) # 600ML
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000004",   15.0,   "00000000-0000-0000-0000-000000000004")) # 2L
#======CAPIVARA===================
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000005",   10.0,   "00000000-0000-0000-0000-000000000005")) # PEQUENO
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000006",   14.0,   "00000000-0000-0000-0000-000000000006")) # MEDIO
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000007",   19.0,   "00000000-0000-0000-0000-000000000007")) # GRANDE
#======CHURROS====================
$price_history_variant.Add(@("00000000-0000-0000-0000-000000000008",   10.0,   "00000000-0000-0000-0000-000000000008")) # MEDIO

#===INSERT
insert "tb_price_history_variant" $price_history_variant



#==PRICE_HISTORY_INGREDIENT===================================================================================
$price_history_ingredient = New-Object System.Collections.Generic.List[object]
#                               ID                                        PRICE   INGREDIENT_ID
#======PASTEL=====================
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000001",   2.0,    "00000000-0000-0000-0000-000000000001")) # CARNE
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000002",   2.0,    "00000000-0000-0000-0000-000000000002")) # QUEIJO
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000003",   2.0,    "00000000-0000-0000-0000-000000000003")) # PIZZA
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000004",   2.0,    "00000000-0000-0000-0000-000000000004")) # CHOCOLATE
#======REFRIGERANTE===============
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000005",   0.0,    "00000000-0000-0000-0000-000000000005")) # COCA-COLA
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000006",   0.0,    "00000000-0000-0000-0000-000000000006")) # PEPSI
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000007",   0.0,    "00000000-0000-0000-0000-000000000007")) # FANTA UVA
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000008",   0.0,    "00000000-0000-0000-0000-000000000008")) # FANTA LARANJA
#======CAPIVARA===================
$price_history_ingredient.Add(@("00000000-0000-0000-0000-000000000009",   2.0,    "00000000-0000-0000-0000-000000000009")) # CARNE
$price_history_ingredient.Add(@("00000000-0000-0000-0000-00000000000a",   2.0,    "00000000-0000-0000-0000-00000000000a")) # QUEIJO
$price_history_ingredient.Add(@("00000000-0000-0000-0000-00000000000b",   2.0,    "00000000-0000-0000-0000-00000000000b")) # PIZZA
$price_history_ingredient.Add(@("00000000-0000-0000-0000-00000000000c",   2.0,    "00000000-0000-0000-0000-00000000000c")) # CHOCOLATE
#======CHURROS====================
$price_history_ingredient.Add(@("00000000-0000-0000-0000-00000000000d",   0.0,    "00000000-0000-0000-0000-00000000000d")) # CHOCOLATE
$price_history_ingredient.Add(@("00000000-0000-0000-0000-00000000000e",   0.0,    "00000000-0000-0000-0000-00000000000e")) # AVELÃ
$price_history_ingredient.Add(@("00000000-0000-0000-0000-00000000000f",   0.0,    "00000000-0000-0000-0000-00000000000f")) # DOCE DE LEITE

#===INSERT
insert "tb_price_history_ingredient" $price_history_ingredient



#==VARIANT_INGREDIENT===================================================================================
$variant_ingredient = New-Object System.Collections.Generic.List[object]
#                         ID                                       AVAILABLE   VARIANT_ID                              INGREDIENT_ID                            | VARIANT - INGREDIENT                            
#======PASTEL=====================  
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000001",  1,          "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000001")) # MEDIO   - CARNE
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000002",  1,          "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000002")) # MEDIO   - QUEIJO
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000003",  1,          "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000003")) # MEDIO   - PIZZA
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000004",  1,          "00000000-0000-0000-0000-000000000001", "00000000-0000-0000-0000-000000000004")) # MEDIO   - CHOCOLATE
#======REFRIGERANTE===============
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000005",  1,          "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000005")) # LATA    - COCA-COLA
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000006",  1,          "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000006")) # LATA    - PEPSI
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000007",  1,          "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000007")) # LATA    - FANTA UVA
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000008",  1,          "00000000-0000-0000-0000-000000000002", "00000000-0000-0000-0000-000000000008")) # LATA    - FANTA LARANJA
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000009",  1,          "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000005")) # 600ML   - COCA-COLA
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000000a",  1,          "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000006")) # 600ML   - PEPSI
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000000b",  1,          "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000007")) # 600ML   - FANTA UVA
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000000c",  1,          "00000000-0000-0000-0000-000000000003", "00000000-0000-0000-0000-000000000008")) # 600ML   - FANTA LARANJA
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000000d",  1,          "00000000-0000-0000-0000-000000000004", "00000000-0000-0000-0000-000000000005")) # 2L      - COCA-COLA
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000000e",  1,          "00000000-0000-0000-0000-000000000004", "00000000-0000-0000-0000-000000000006")) # 2L      - PEPSI
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000000f",  1,          "00000000-0000-0000-0000-000000000004", "00000000-0000-0000-0000-000000000007")) # 2L      - FANTA UVA
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000010",  1,          "00000000-0000-0000-0000-000000000004", "00000000-0000-0000-0000-000000000008")) # 2L      - FANTA LARANJA
#======CAPIVARA===================
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000011",  1,          "00000000-0000-0000-0000-000000000005", "00000000-0000-0000-0000-000000000009")) # PEQUENO - CARNE 
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000012",  1,          "00000000-0000-0000-0000-000000000005", "00000000-0000-0000-0000-00000000000a")) # PEQUENO - QUEIJO
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000013",  1,          "00000000-0000-0000-0000-000000000005", "00000000-0000-0000-0000-00000000000b")) # PEQUENO - PIZZA
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000014",  1,          "00000000-0000-0000-0000-000000000005", "00000000-0000-0000-0000-00000000000c")) # PEQUENO - CHOCOLATE
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000015",  1,          "00000000-0000-0000-0000-000000000006", "00000000-0000-0000-0000-000000000009")) # MEDIO  - CARNE 
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000016",  1,          "00000000-0000-0000-0000-000000000006", "00000000-0000-0000-0000-00000000000a")) # MEDIO  - QUEIJO
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000017",  1,          "00000000-0000-0000-0000-000000000006", "00000000-0000-0000-0000-00000000000b")) # MEDIO  - PIZZA
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000018",  1,          "00000000-0000-0000-0000-000000000006", "00000000-0000-0000-0000-00000000000c")) # MEDIO  - CHOCOLATE
$variant_ingredient.Add(@("00000000-0000-0000-0000-000000000019",  1,          "00000000-0000-0000-0000-000000000007", "00000000-0000-0000-0000-000000000009")) # GRANDE - CARNE 
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000001a",  1,          "00000000-0000-0000-0000-000000000007", "00000000-0000-0000-0000-00000000000a")) # GRANDE - QUEIJO
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000001b",  1,          "00000000-0000-0000-0000-000000000007", "00000000-0000-0000-0000-00000000000b")) # GRANDE - PIZZA
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000001c",  1,          "00000000-0000-0000-0000-000000000007", "00000000-0000-0000-0000-00000000000c")) # GRANDE - CHOCOLATE
#======CHURROS====================
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000001d",  1,          "00000000-0000-0000-0000-000000000008", "00000000-0000-0000-0000-00000000000d")) # MEDIO  - CHOCOLATE
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000001e",  1,          "00000000-0000-0000-0000-000000000008", "00000000-0000-0000-0000-00000000000e")) # MEDIO  - AVELÃ
$variant_ingredient.Add(@("00000000-0000-0000-0000-00000000001f",  1,          "00000000-0000-0000-0000-000000000008", "00000000-0000-0000-0000-00000000000f")) # MEDIO  - DOCE DE LEITE

#===INSERT
insert "tb_variant_ingredient" $variant_ingredient