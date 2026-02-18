# SI_Devoir5
## Strategy, Observer, and State - 5 points

## Diagramme de classes UML réalisé avec draw.io.  3,5 points
## Code 1,5 point

L’objectif est de simuler le fonctionnement d’une plateforme de commerce électronique dans la gestion de différents moyens de paiement, des notifications de paiement et des états de transaction.

Le patron de conception Strategy sera utilisé pour gérer des moyens de paiement interchangeables tels que la carte de crédit, PayPal ou les cryptomonnaies.

Le patron de conception Observer permettra l’envoi automatique de notifications à plusieurs observateurs (courriel et SMS) chaque fois que le statut du paiement change.

Le patron de conception State représentera le déroulement du processus de paiement en gérant les transitions entre les états Pending, Completed et Failed.

Le programme doit permettre à l’utilisateur de saisir un montant, de choisir un moyen de paiement et de simuler un processus de paiement complet. Lorsqu’un paiement est traité, le système doit passer par différents états et notifier automatiquement les observateurs à chaque changement de statut.

Vous êtes encouragés à démarrer le code et le diagramme de classes en vous basant sur notre cours sur le patron de conception Strategy (le code et le diagramme vus en classe).
