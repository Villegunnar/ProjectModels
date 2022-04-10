  
### För att kunna få VG ska du:
### 1. Skriva ett resonemang kring din arkitektur och dina val av tekniska metoder i din readme-fil i ditt GIT-repo.
   Detta resonemang ska vara nyanserat, dvs du ska resonera kring för och nackdelar med din lösning i projektet.


###### Jag började med att skapa mina 3 klasser Employee, Project och TimeReport. Jag designade min arkitektur i TimeReport klassen så att den innhöll en foreinkey av Employee klassen (EmployeeId) och en foreinkey av Project klassen (ProjectId) på detta sätt blev TimeReport min kopplingstabell där de kopplas ihop via respektive  relationer.
###### Jag gjorde sen en brygga (ProjectDbContext) för att kunna nå min databas och fyllde även på seed data här för respektive tabell i databasen. Detta för att sedan köra min Initial Migration och update-database.
###### Efter det gjorde jag ett interface (IProgramRepository<T>) med hänsyn till Repository Pattern, innehållande dem metoderna som jag behöver för att uppfylla kraven på projektet.
###### Jag skapade också 3 Repository klasser. En som hanterar logiken för Employee klassen, en för Project klassen och en för TimeReport klassen. Dessa 3 Repository klasserna ärver av (IProgramRepository<T>) interfacet så att varje klass kunde få sin specifika logik för sitt ändamål.  
###### Jag skrev sedan all logik till varje metod tillhörande sin klass så att till exempel GetAll metoden i Employee klassen hämtar alla Employee uppgifter osv.
   
###### Jag skapade sedan en Controller var till Employee, Project och TimeReport så att jag kan nå rätt metod via en sin egen Url adress och så att varje metod i sin Controller klass får sin unika adress och inte krockar med en annan metod.
   
###### Fördelar med min arkitektur är att det är lätt att bygga ut fler metoder och logik. Jag har följt och haft hänsyn till Repository pattern och jag tycker lätt att förstå programmet om man skulle titta för första gången då den håller en väldigt tydlig struktur och rödtråd igenom.

###### Nackdelar skulle vara att jag har designat mina metoder så att även data som uppgiften inte kräver föjler med. Det hade varit snyggare om tex GetEmpWithTime bara visade tiden som den anställde har stämplat och inte vilken vecka. Samma sak i GetEmpWithProject, där ser man även tiden som den anställde jobbat på varje projekt. Ett filter som tar bort onödig data hade gjort programmet lite snyggare tycker jag.
