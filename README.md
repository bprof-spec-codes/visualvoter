
 # VotÓE &nbsp;&nbsp; - &nbsp;&nbsp;[![N|Solid](https://i.imgur.com/DF1phUJ.png)](https://votoe.hu)
### Team Visualvoter

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
- ### Használat:
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

### API funkciólista:
 
<br/>
 
### UI felületek rövid ismertetése:

#### Főoldal
![](https://i.imgur.com/Uwhf4Ym.png)
 #### Bejelentkezés
![](https://i.imgur.com/TWPCA53.png)
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
