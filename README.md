# DS_Gr24_2020

Projekti 1,2,3 ne Sigurine e te dhenave.

****************************************************************************************************

       Projekti 1
                                     

Komandat :

tap-code , 
rail-fence , 
beale 


****************************************************************************************************

       Projekti 2
                                     

Komandat :

create-user , 
delete-user , 
export-key , 
import-key , 
write-message , 
read-message 

****************************************************************************************************
            
Pershkrimi i komanandave :

create-user:
Krijon një çift të publik/privat të RSA me emrat <name>.xml dhe <name>.pub.xml brenda
direktoriumit të çelësave keys.

delete-user:
I largon të gjithë çelësat ekzistues të shfrytëzuesit.

export-key:
Eksporton çelësin publik ose privat të shfrytëzuesit nga direktoriumi i çelësave.

import-key:
Importon çelësin publik ose privat të shfrytëzuesit nga shtegu i dhënë dhe e vendos në direktoriumin
e çelësave.

write-message:
E shkruan një mesazh të enkriptuar të dedikuar për një shfrytëzues.

read-message:
E dekripton dhe e shfaq në console mesazhin e enkriptuar.


*****************************************************************************************************

     Projekti 3
 
 
Komandat : 
create-user , 
delete-user , 
login , 
status , 
write-message , 
read-message 

*****************************************************************************************************

Pershkrimi i komandave :

create-user:
Zgjerimi i komandes create-user ashtu qe gjate krijimit te shfrytezuesit te kerkohet edhe fjalekalimi i 
jepet permes input-it dhe te jete se paku 6 karaktere dhe kur shfrytezuesi krijohet duhet te ruhet ne bazen 
e shenimeve

delete-user:
Kur të thirret kjo komandë do të fshihen edhe të gjitha të dhënat e shfrytëzuesit nga baza e
shënimeve.

login:
Teston shfrytezuesin dhe fjalekalimin .Në rast suksesi lëshohet një token i nënshkruar i cili mund të
përdoret për autentikim të shfrytëzuesit.Tokeni skadon pas 20 minutave. Tokeni mund të përdoret vetëm për shfrytëzuesin për të cilin është
lëshuar.

status:
Ne rast se tokeni ka skaduar ose nese nuk ekziston shfrytezuesi atehere tokeni eshte jo-valid.

write-message:
Ka te beje me opsionin sender e kjo e fundit deshton nese tokeni nuk eshte valid.

read-message
Nëse mungon pjesa e dërguesit/nënshkrimit, atëherë komanda e injoron dhe vepron sikur në fazën e
dytë.
*****************************************************************************************************


