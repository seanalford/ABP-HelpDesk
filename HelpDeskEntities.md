## Help Desk Entities

##### Back to the [Help Desk Tutorial](README.md), or on to the next step [Create Help Desk Solution](CreateHelpDeskSolution.md)

\* denotes required fields.

##### Ticket Status : FullAuditedAggregateRoot
|   | Property      | Type                     | Min | Max  | Examples                         |
|---|---------------|--------------------------|-----:|-----:|----------------------------------|
| * | Name          | string                   | 1   | 20   | New, In Progress, On Hold, Close |

##### Customer : FullAuditedAggregateRoot
|   | Property      | Type                     | Min  | Max  | Examples                         |
|---|---------------|--------------------------|-----:|-----:|----------------------------------|
|   | Number        | string                   |      | 20   | CID-00001, CUST-00001, BW-000001 |
| * | Name          | string                   |      | 250  | Acme, ABC, Volo                  |

##### Contact : FullAuditedAggregateRoot
|   | Property      | Type                     | Min  | Max  | Examples                         |
|---|---------------|--------------------------|-----:|-----:|----------------------------------|
| * | Name          | string                   |      | 100  | John                             |
| * | Surname       | string                   |      | 100  | Doe                              |
| * | Phone         | string                   |      | 20   |                                  |
|   | Email         | string                   |      | 250  | john.doe@acme.com                |

##### Issue : FullAuditedAggregateRoot
|   | Property      | Type                     | Min  | Max  | Examples                         |
|---|---------------|--------------------------|-----:|-----:|----------------------------------|
| * | Description   | string                   |      | 2000 | Cannot connect to device.        |
| * | Tags          | string                   |      | 500  | Acme Product, V5.8, Connection   |
|   | Solution      | string                   |      | 2000 | Turned device on connect OK      |

- Would be nice if you could select multipl tags from a list.
- Maybe add a steps to reproduce property.
- Maybe add a trouble shooting checklist.

##### Ticket : FullAuditedAggregateRoot
|   | Property      | Type                     | Min  | Max  | Examples                         |
|---|---------------|--------------------------|-----:|-----:|----------------------------------|
| * | TicketStatusId| guid                     |      |      | Navigation Property              |
| * | Number        | string                   |      | 15   | (auto) T-00001, T-00002, T-00003 |
| * | ContactId     | guid                     |      |      | Navigation Property              |
| * | Customerd     | guid                     |      |      | Navigation Property              |
| * | Description   | guid                     |      |      | Cannot connect to my Acme device.|
|   | IssueId       | guid                     |      |      | Navigation Property              |

##### Back to the [Help Desk Tutorial](/README.md), or on to the next step [Creating Help Desk Solution](CreatingHelpDeskSolution.md)
