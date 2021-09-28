namespace RxBim.CommandExample.Services
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Abstractions;
    using Autodesk.Revit.DB;
    using Autodesk.Revit.UI;
    using Tools.Revit.Abstractions;
    using Result = CSharpFunctionalExtensions.Result;

    /// <inheritdoc/>
    public class MyService : IMyService
    {
        private readonly IElementsCollector _elementsCollector;
        private readonly IProblemElementsStorage _problemElementsStorage;
        private readonly ISheetsCollector _sheetsCollector;
        private readonly Document _doc;
        private readonly RevitTask _revitTask;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="elementsCollector">collector</param>
        /// <param name="problemElementsStorage">problems elements</param>
        /// <param name="sheetsCollector"><see cref="ISheetsCollector"/></param>
        /// <param name="doc">doc</param>
        /// <param name="revitTask">revit task</param>
        public MyService(
            IElementsCollector elementsCollector,
            IProblemElementsStorage problemElementsStorage,
            ISheetsCollector sheetsCollector,
            Document doc,
            RevitTask revitTask)
        {
            _elementsCollector = elementsCollector;
            _problemElementsStorage = problemElementsStorage;
            _sheetsCollector = sheetsCollector;
            _doc = doc;
            _revitTask = revitTask;
        }

        /// <inheritdoc/>
        public async Task<Result> Go()
        {
            try
            {
                var sheets = _sheetsCollector.GetSheets("Орг.КомплектЧертежей");

                await _revitTask.Run((app) =>
                {
                    var elements = _elementsCollector
                        .GetFilteredElementCollector(_doc)
                        .WhereElementIsNotElementType()
                        .ToElements()
                        .ToList();

                    // Use Transaction

                    // Add problem element to storage
                    var problemElem = elements.FirstOrDefault();
                    if (problemElem != null)
                        _problemElementsStorage.AddProblemElement(problemElem.Id.IntegerValue, "problem description");
                });

                TaskDialog.Show(GetType().FullName, _doc.Title);
                return Result.Success();
            }
            catch (Exception exception)
            {
                return Result.Failure(exception.Message);
            }
        }
    }
}