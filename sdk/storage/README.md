# Azure Storage libraries for .NET

Azure Storage is a Microsoft-managed service providing cloud storage that is highly available, secure, durable, scalable, and redundant.  Azure Storage includes Blobs (objects), Queues, and Files.

- [Azure.Storage.Blobs][blobs] is Microsoft's object storage solution for the cloud. Blob storage is optimized for storing massive amounts of unstructured data that does not adhere to a particular data model or definition, such as text or binary data.

- [Azure.Storage.Queues][queues] is a service for storing large numbers of messages.  A queue message can be up to 64 KB in size and a queue may contain millions of messages, up to the total capacity limit of a storage account.

- [Azure.Storage.Files][files] offers fully managed file shares in the cloud that are accessible via the industry standard Server Message Block (SMB) protocol.  Azure file shares can be mounted concurrently by cloud or on-premises deployments of Windows, Linux, and macOS.

- [Azure.Storage.Common][common] provides infrastructure shared by the other Azure Storage client libraries like shared key authentication and exceptions.

- [Microsoft.Azure.Management.Storage][management] supports managing Azure Storage resources, including the creation of new storage accounts.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq]
or contact [opencode@microsoft.com][coc_contact] with any
additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net%2Fsdk%2Fstorage%2FREADME.png)

<!-- LINKS -->
[blobs]: ./Azure.Storage.Blobs/README.md
[queues]: ./Azure.Storage.Queues/README.md
[files]: ./Azure.Storage.Files/README.md
[common]: ./Azure.Storage.Common/README.md
[management]: ./Microsoft.Azure.Management.Storage/
[cla]: https://cla.microsoft.com
[coc]: https://opensource.microsoft.com/codeofconduct/
[coc_faq]: https://opensource.microsoft.com/codeofconduct/faq/
[coc_contact]: mailto:opencode@microsoft.com
