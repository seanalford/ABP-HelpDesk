# [ABP Suite](https://commercial.abp.io/tools/suite) - Help Desk Tutorial - Part 3

### About this tutorial:

- [Part-1: - Help Desk Domain Model](Part1-HelpDeskDomainModel.md) 
- [Part-2: - Create the Help Desk Solution](Part2-MVC-CreateHelpDeskSoluton.md)
- Part-3: - Create the Help Desk Entities
- [Part-4: - Customize the Help Desk](Part4-MVC-CustomizeHelpDesk.md)

### Overview

In this tutorial we will demonstrate how to build the Help Desk entities.
### Create TicketStatus

In the `Acme.HelpDesk.Domain.Shared` project, create a new folder named `TicketStatus`.
Next, in the `TicketStatus` folder create a new class file named `TicketStatus.cs` containing the following code.

#### TicketStatus.cs

```c#
namespace Acme.HelpDesk.TicketStatus
{
    public enum TicketStatus
    {
        New,
        InProgress,
        OnHold,
        Closed,
    }
}
``` 

### Create Oranization

### Extend AppUser

### Create AnswerReply

### Create Answer

### Create Tag

### Create Ticket

