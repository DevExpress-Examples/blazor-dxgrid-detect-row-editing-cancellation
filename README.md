<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1132900)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Grid for Blazor - Create a custom cancel editing confirmation dialog

This example illustrates how to display a confirmation dialog in the [DevExpress Blazor Grid](https://docs.devexpress.com/Blazor/403143/grid) when a user does not save the changes made to the currently edited row, but starts editing another row. To implement the confirmation dialog, our [Popup](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxPopup) component is used. It displays a confirmation message and custom **Save** and **Cancel** buttons that allow users to save and cancel the pending changes. 

![Confirmation Dialog](confirmation-dialog.gif)

In this example, the Grid displays the [inline editors](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditrow) instead of the edited data row. However, the described approach is also applicable to the Grid that displays the [edit form](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditform-default).

## Overview

A user can click the **Edit** button in the Grid component's command column to start editing a row. If another row is being edited at this moment, the Grid stops the old row editing and cancels unsaved changes, if any. To implement a confirmation dialog that prevents the loss of unsaved changes in such cases, follow the steps below:

1. Configure the Grid component to allow users edit its data. Refer to the following help topic for more information: [Edit Data and Validate Input](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input).

2. Add the [Popup](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxPopup) component to the page. Use the component's [FooterContentTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxPopupBase.FooterContentTemplate) property to display custom **Save** and **Cancel** buttons in the footer of the pop-up window. The [BodyContentTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxPopupBase.BodyContentTemplate) property allows you to display a confirmation message in the body area of the pop-up window.

3. Save the Grid edit context within the edit template, which you specified in the step 1. Depending on the [editing mode](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditMode), it can be an [EditFormTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.EditFormTemplate), [DataColumnCellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.DataColumnCellEditTemplate), or [CellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridDataColumn.CellEditTemplate). In the latter case, save the context in every `CellEditTemplate` to get the valid context, even if some grid columns are hidden.

4. Define the Grid's [CellDisplayTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridCommandColumn.CellDisplayTemplate) to implement a custom **Edit** button. In this button's [Click](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxButton.Click) event handler, use the editing context to check whether the Grid component has unsaved changes. If the Grid has unsaved changes, save the [newly selected item](https://docs.devexpress.com/Blazor/DevExpress.Blazor.GridColumnCellDisplayTemplateContext.DataItem) and show the Popup component; otherwise, start editing the new item.

5. Handle the `Click` events of the Popup component's **Save** and **Cancel** buttons. If a user clicks the **Save** button, save pending changes and close the popup. If a user clicks the **Cancel** button, just close the popup.

6. Handle the Popup component's [Closed](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxPopupBase.Closed) event. In this event handler, start editing the saved item.

## Files to Review

- [Index.razor](./CS/ShowConfirmationDialog/Pages/Index.razor)

## Documentation

- [Bind the Grid to Data](https://docs.devexpress.com/Blazor/403737/grid/bind-to-data)
- [Edit Grid Data and Validate Input](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input)

## More Examples

- [Grid for Blazor - How to post changes to an in-memory data source](https://github.com/DevExpress-Examples/blazor-dxgrid-post-changes-to-data-source)
- [Grid for Blazor - Create a custom record deletion confirmation dialog](https://github.com/DevExpress-Examples/blazor-dxgrid-show-custom-confirmation-dialog)
- [Grid for Blazor – How to activate EditRow mode and define data editors for row cells](https://github.com/DevExpress-Examples/blazor-grid-row-editing)
