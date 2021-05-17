# VotÓE &nbsp;&nbsp; - &nbsp;&nbsp;[![N|Solid](https://i.imgur.com/DF1phUJ.png)](https://votoe.hu)

### Team Visualvoter
Kihostolt weboldalunk: https://votoe.hu/

## Tartalomjegyzék:
- [Csapatbeosztás](#csapatbeosztás)
- [User Manual](#user-manual)
	 - [Telepítés / Üzemeltetés](#telepítés--üzemeltetés)
	 - [Login Credentials](#login-credentials)
	 - [API funkciólista](#api-funkciólista)
	 - [UI felületek rövid ismertetése](#ui-felületek-rövid-ismertetése)
- [Probléma Jegyzőkönyv](#probléma-jegyzőkönyv)
<br/>

## Csapatbeosztás:
- ### Team Leader:
     - Tuba Márk
- ### Frontend (React):
     - Papp Bence
- ### Backend (Asp api):
     - Pap Tamás
     - Luxeder Zoltán
<br/>

## User Manual:
- ### Telepítés / Üzemeltetés:
	 - Frontend(React)
		 - Első lépésként Reacthez szükségünk lesz a node.js és npm-hez.
		 - https://nodejs.org/en/ itt le lehet tölteni, nem kell semmit se csinálni telepítés közbe csak végig kattintani.
		 ![](https://i.imgur.com/kXtiGLu.png)
		 - Miután letöltöttük a node.js-t navigáljunk el az alábbi directory-be.
		 ![](https://i.imgur.com/PZkFlL6.png)
		 - Indítsuk el a CMD-t úgy hogy "cmd "-t írunk a directory path elejére.
		 ![](https://i.imgur.com/wzErTNO.png)
		 - Első indításkor "npm install" kell beírnunk.
		 ![](https://i.imgur.com/nVdqlpm.png)
		 - Utána csak "npm start" ra lesz szükségünk az app elindításához.
		 ![](https://i.imgur.com/hKCLKyC.png)
	 - Backend
		 - Ha saját szervert szeretnél használni akkor az alábbiakat kell elvégezni:
			 - Navigálj az alábbi directoryba:
			 ![](https://i.imgur.com/2rwNVeW.png)
			 - Tetszőleges szövegszerkeztővel nyissuk meg a Startup.cs fájlt(NotePad++ vagy Visual Studio Code ajánlott).
			 ![](https://i.imgur.com/nBP2CMt.png)
			 - Menjünk el a 73.sorig a connectionStringhez és írjuk át a saját szerverünkre.
			 ![](https://i.imgur.com/nJdVk25.png)
		 - Backend API Endpoint beüzemeltetés:
			 - Navigálj az alábbi directoryba.
			 ![](https://i.imgur.com/WnYNOhM.png)
			 - Inditsuk el a VotoeBackend.sln fájlt.
			 ![](https://i.imgur.com/SZnYmuu.png)
			 - Jobb oldalt jobb kattintással nyomjunk rá a VotOEApi-ra és menjünk rá a Build-re.
			 ![](https://i.imgur.com/iOKI7rt.png)
			 - Ezután navigáljunk el az adott pontra és indítsuk el a VotOEApi.exe fájlt és készen is vagyunk.
			 ![](https://i.imgur.com/Cxmmhev.png)
<br/>

- ### Login Credentials:
	 - Alapvető user <> pass kombinációk:
		 - Admin Felhasználói Fiók:
			 -  E-mail-cím: admin@votoe.hu
			 -  Jelszó: jelszo
	 - Tesztelésre Használt Felhasználói Fiókok:
		 - Test1:
			-  E-mail-cím: test1@stud.uni-obuda.hu
			-  Jelszó: string
		- Test2:
			-  E-mail-cím: test2@stud.uni-obuda.hu
			-  Jelszó: string
		- Test3:
			-  E-mail-cím: test3@stud.uni-obuda.hu
			-  Jelszó: string

<br/>

- ### API funkciólista:
- Allvotes API:
	- [DELETE]​/AllVotes​/{id}: Kitöröl az adatbázisból egy szavazást ID alapján.
	- [GET]/AllVotes: Visszaküldi az összes szavazást.
	- [GET]​/AllVotes​/{id}: Visszaküldi a keresett szavazást ID alapján.
	- [GET​]/AllVotes​/active: Visszaküldi az összes jelenleg aktív szavazást.
	- [GET]​/AllVotes​/usersVotes: Visszaküldi az összes szavazást ami elérhető egy adott felhasználónak(role-nak).
	- [GET]​/AllVotes​/close​/{id}: Bezár egy szavazást ID alapján.
	- [GET​]/AllVotes​/finish​/{id}: Befejez egy szavazást ID alapján.
	- [GET]​/AllVotes​/groupVotes?groupName=example: Visszaküldi az összes szavazást amely az adott  "example" csoportba tartozik.
	- [GET​]/AllVotes​/participantCount?groupName=example: Visszaküldi az összes személyt aki az adott "example" csoportba tartozik.
	- [GET]​/AllVotes​/winCheck?voteID=123: Egy bool értéket küldd vissza, az alapján hogy a megadott szavazást valaki megnyerte vagy nem. A szavazást ID alapján keressük meg.
	- [POST]/AllVotes: Hozzád egy új szavazást az adatbázisba.
	- [PUT]​/AllVotes​/{oldId}: Frissít egy szavazást ID alapján.

<br/>

- Auth API:
	- [DELETE​]/Auth​/{id}: Töröl egy felhasználói fiókot ID alapján.
	- [GET​]/Auth: Visszaküldi az összes felhasználót.
	- [GET​]/Auth​/getOne?id=123: Visszaküld egy felhasználót ID alapján.
	- [GET​]/Auth​/allRoles: Visszaküldi az összes role-t.
	- [GET​]/Auth​/createRole?RoleName=example: Létrehoz egy új role-t "example" névvel.
	- [GET​]/Auth​/test: Debugra használt endpoint ami egy RoleModelt küldd vissza.
	- [GET​]/Auth​/makeAdmin?email=test%40stud.uni-obuda.hu: "test@stud.uni-obuda.hu" email címmel rendelkező felhasználót adminná teszi.
	- [GET​]/Auth​/requestNewRole?roleName=example: Kér egy új role-t a felhasználóra.
	- [GET​]/Auth​/roleRequests: Visszaküldi az összes role kérést.
	- [POST​]/Auth: Létrehoz egy új felhasználót.
	- [POST​]/Auth​/assignRole: Adott felhasználónak egy vagy több új role-t ad.
	- [POST​]/Auth​/createRoleForVote: Egy új role-t ad egy szavazásra.
	- [POST​]/Auth​/requestNewRole: Kér egy új role-t a felhasználóra.
	- [POST​]/Auth​/userRoles: Visszaküldi az összes role-t amivel a felhasználó rendelkezik.
	- [PUT​]/Auth: Felhasználó belépése.
	- [PUT​]/Auth​/{oldId}: Frissít egy felhasználót ID alapján.

<br/>

- OneVote API:
	- DELETE​/OneVote​/{id}: Kitöröl egy szavazatot ID alapján.
	- GET​/OneVote: Visszaküldi az összes szavazatot.
	- GET​/OneVote​/{id}: Visszaküld egy szavazatot ID alapján.
	- POST​/OneVote: Berak egy szavazatot.
	- PUT​/OneVote​/{oldId}: Frissít egy szavazot ID alapján.

<br/>

### UI felületek rövid ismertetése:
#### Főoldal
![](https://i.imgur.com/Uwhf4Ym.png)
#### Bejelentkezés
![](https://i.imgur.com/TWPCA53.png)
#### Regisztráció
![](https://i.imgur.com/XAjMDrp.png)
#### Bejelentkezett Felhasználó Főoldala
![](https://i.imgur.com/omLiKqM.png)
#### Aktív Szavazások Megtekintése 
![](https://i.imgur.com/y3PCNRu.png)
#### Szavazásra Szavazás
![](https://i.imgur.com/ZtnWvNs.png)
#### Admin Felület
![](https://i.imgur.com/Wa6uiDZ.png)
#### Profil Menu / Role Kérés
![](https://i.imgur.com/ztaVexA.png)
#### Kijelentkezés akármikor lehetséges
![](https://i.imgur.com/VIoIKbm.png)

<br/>
 
## Probléma Jegyzőkönyv:
- ### **Probléma #1:**
	 Frontenden egy felhasználó képes volt hozzáférni olyan felületekhez amelyekhez nem kéne lennie jogosultsága.
	 Például a Hök tag hozzáfért az admin vagy editor felülethez.
- ### **Megoldás #1:**
	 Amikor belépünk a weboldalon egy felhasználóba akkor a Backend visszaküld egy tokent.
	 Az volt a legegyszerűbb megoldás hogy a tokenben amit visszaküldünk backendről belehelyezünk egy **IsEditor** és egy **IsAdmin** propertyt, aminek a segítségével frontenden egy egyszerű if statementel megoldható.
<br/>

- ### **Probléma #2:**
	 A szavazatok nem voltak összekötve semmivel és nem tudtuk eldönteni hogy akkor ki nyer egy szavazáson.
- ### **Megoldás #2:**
	 A megoldás amiben maradtunk eléggé egyszerű volt, de eleinte gondolkoztunk néhány más opcióban.
	 Eleinte azon agyaltunk hogy kettébontanánk az allvotes táblát még egy új candidates táblára.
	 Ez a megoldás viszont eszméletlen nagy baj lenne úgy hogy inkább a táblák bontása helyett valami más megoldást kerestünk.
	 Ekkor jött a szavazások kiegészítése egy **groupName** tulajdonsággal amely alapján nagyon könnyen összetudjuk kötni őket még a rendszerrel is ami nekünk van.
	 Ebben a megoldásban maradtunk végülis és rendesen működik vele minden, még azt is könnyen eltudjuk dönteni hogy ki nyer a szavazáson ezzel.
<br/>

- ### **Probléma #3:**
	 Az authentikációval meg a felhasználóval kapcsolatos fejlesztéseket magunktól elkezdtük csinálni, ezután kijött az Autentikációs videó szakirányon és nagyon sok minden más volt.
	 Eleinte nem voltunk biztosak mennyire nagy probléma lesz ez, de elég nagynak tűnt akkoriban.
	 Természetesen a videó alapján megcsináltuk az authentikációt ami miatt minden eddigi authentikációssal kapcsolatos munkának nagyrészét változtatni kellet.
	 Ilyenekre kell gondolni mint **DbContext**-et kicserélni **IdentityDbContext**-re meg hasonlóakra.
	 Elég sok elavult methódust is természetesen ki kellett törölni.
<br/>

- ### **Probléma #4:**
	 Egy ember csak egyszer szavazhasson és csak azokon ahol van jogosultsága.
- ### **Megoldás #4:**
	 Amikor még terveztük a rendszereket belefutottunk ebbe a problémába.
	 Aztán erre jött a megoldás hogy minden szavazásnál külön role-t generálálunk azoknak akinek van joguk szavazni erre a szavazásra.
	 Ezt a plusszba készített role-t amikor sikeresen szavaz egy felhasználó akkor leszedjük róla.
<br/>

- ### **Probléma #5:**
	 
- ### **Megoldás #5:**