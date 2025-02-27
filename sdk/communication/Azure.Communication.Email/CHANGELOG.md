# Release History

## 1.0.0-beta.3 (Unreleased)

### Features Added

### Breaking Changes

### Bugs Fixed

### Other Changes

## 1.0.0-beta.2 (2023-03-01)

### Features Added
- AAD token auth has been added for `EmailClient` and `EmailAsyncClient`

### Breaking Changes
- Changed: Reworked the SDK to follow the LRO (long running operation) approach. The 'Send' method returns an `Azure.Operation` that can be used to retrieve the status of the email request. The result object is a status monitor that contains the OperationID as well as the current status and error if any.
- Changed: We have added some convenience overloads to the Send method for quickly sending an email with a from address, to address and simple message.
- Changed: The `EmailMessage` model now has convenience overloads for when you want to quickly create an EmailMessage with a single from and to email address.
- Changed: The `EmailAttachment` constructor now accepts BinaryData instead of a string.
- Changed: The `contentBytesBase64` property under `attachments` has been changed to `contentInBase64`.
- Changed: The `attachmentType` property under `attachments` has been changed to 'contentType'. This now accepts a string representing the mime type of the content being attached.
- Changed: The `sender` property has been changed to `senderAddress`.
- Changed: The `email` property under the recipient object has been changed to `address`.
- Changed: Custom headers in the email message are now key/value pairs.
- Changed: ASP.Net extensions have been added for the `EmailClient`. 
- Removed: The `EmailAttachmentType` enum has been removed.
- Removed: The importance property was removed. Email importance can now be specified through either the `x-priority` or `x-msmail-priority` custom headers.
- Removed: The `getSendStatus` method has been removed.

## 1.0.0-beta.1 (2022-05-24)
Initial version of the Azure Communication Services Email service
- Send emails to multiple recipients with attachments
- Get the status of a sent message
