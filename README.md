# Proiect

Tema proiectului este realizarea unei aplicații pentru gestionarea închirierii de mașini într-o firmă de rent-a-car.
Aplicația este destinată angajaților unui birou de închirieri auto și permite administrarea mașinilor disponibile și gestionarea procesului de închiriere pentru clienți. Pentru a utiliza aplicația, angajații trebuie să se autentifice folosind datele de conectare furnizate de firmă.


Conform temei propuse aplicatia trebui sa contina urmatoarele operatiuni

afișarea listei cu toate mașinile firmei

vizualizarea mașinilor disponibile pentru închiriere

introducerea datelor unui client (nume, prenume, CNP)

realizarea unei închirieri pentru o anumită perioadă (data de început și data de final)

salvarea închirierilor în baza de date

marcarea automată a mașinii ca indisponibilă pe perioada închirierii


## Clasele aplicației

Aici se vor afla informatiile necesare pentru a descrie clasele pe care le contine proiectul meu 

Clasele pe care le va contine aplicatia mea sunt:

### Masina
Reprezintă o mașină disponibilă pentru închiriere.
Conține informații precum marca, modelul, anul fabricației și prețul pe zi.
De asemenea, conține un atribut care indică dacă mașina este disponibilă sau nu.

### Client
Reprezintă persoana care dorește să închirieze o mașină.
Datele stocate sunt numele, prenumele și CNP-ul clientului.

### Angajat
Reprezintă angajatul firmei care utilizează aplicația.
Această clasă conține date de autentificare (username și parolă).

### Inchiriere
Reprezintă procesul de închiriere al unei mașini de către un client.
Include informații despre client, mașină și perioada de închiriere.

### FirmaInchirieri
Această clasă gestionează listele de mașini, clienți și închirieri și oferă metode pentru
adăugarea de mașini și realizarea unei închirieri.
