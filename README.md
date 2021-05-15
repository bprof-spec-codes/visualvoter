

# VotÓE &nbsp;&nbsp; - &nbsp;&nbsp;[![N|Solid](https://i.imgur.com/DF1phUJ.png)](https://votoe.hu)

### Team Visualvoter

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
	 - 
- ### Login Credentials:
	 - Alapvető user <> pass kombinációk:
		 - Admin Felhasználói Fiók:
			 -  E-mail-cím: admin@votoe.hu
			 -  Jelszó: jelszo

<br/>
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
	- [DELETE]​/AllVotes​/{id}: Kitöröl az adatbázisből egy szavazást ID alapján.
	- [GET]/AllVotes: Visszaküldi az összes szavazást.
	- [GET]​/AllVotes​/{id}: Visszaküldi a keresett szavazást ID alapján.
	- [GET​]/AllVotes​/active: Visszaküldi az összes jelenleg aktív szavazást.
	- [GET]​/AllVotes​/usersVotes: Visszaküldi az összes szavazást ami elérhető egy adott felhasználónak(role-nak).
	- [GET]​/AllVotes​/close​/{id}: Bezár egy szavazást ID alapján.
	- [GET​]/AllVotes​/finish​/{id}: Befejez egy szavazást ID alapján.
	- [GET]​/AllVotes​/groupVotes?groupName=example: Visszaküldi az összes szavazást amely az adott  "example" csoportba tartozik.
	- [GET​]/AllVotes​/participantCount?groupName=example: Visszaküldi az összes személyt aki az adott "example" csoportba tartozik.
	- [GET]​/AllVotes​/winCheck?voteID=123:  Egy bool értéket küldd vissza, az alapján hogy a megadott szavazást valaki megnyerte vagy nem. A szavazást ID alapján keressük meg.
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
	- GET​/OneVote:  Visszaküldi az összes szavazatot.
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
	 
- ### **Megoldás #2:**
<br/>

- ### **Probléma #3:**
	 
- ### **Megoldás #3:**
<br/>

- ### **Probléma #4:**
	 
- ### **Megoldás #4:**
<br/>

- ### **Probléma #5:**
	 
- ### **Megoldás #5:**
