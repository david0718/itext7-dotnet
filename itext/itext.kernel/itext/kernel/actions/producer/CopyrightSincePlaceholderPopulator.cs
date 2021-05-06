/*
This file is part of the iText (R) project.
Copyright (c) 1998-2021 iText Group NV
Authors: iText Software.

This program is offered under a commercial and under the AGPL license.
For commercial licensing, contact us at https://itextpdf.com/sales.  For AGPL licensing, see below.

AGPL licensing:
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using iText.IO.Util;
using iText.Kernel;
using iText.Kernel.Actions.Events;

namespace iText.Kernel.Actions.Producer {
    /// <summary>Class is used to populate <c>copyrightSince</c> placeholder.</summary>
    /// <remarks>
    /// Class is used to populate <c>copyrightSince</c> placeholder. The resulting string is a
    /// representation of the first year of copyright years range. Among all products involved into
    /// product creation the earliest <c>copyrightSince</c> year is picked as a resulting value.
    /// </remarks>
    internal class CopyrightSincePlaceholderPopulator : IPlaceholderPopulator {
        /// <summary>
        /// Builds a replacement for a placeholder <c>copyrightSince</c> in accordance with the
        /// registered events.
        /// </summary>
        /// <param name="events">
        /// is a list of event involved into document processing. It is expected that it
        /// is not empty as such cases should be handled by
        /// <see cref="ProducerBuilder"/>
        /// without
        /// calling any
        /// <see cref="IPlaceholderPopulator"/>
        /// </param>
        /// <param name="parameter">
        /// is a parameter for the placeholder. It should be <c>null</c> as
        /// <c>copyrightSince</c> as the placeholder is not configurable
        /// </param>
        /// <returns>the earliest copyright year</returns>
        public virtual String Populate(IList<ITextProductEventWrapper> events, String parameter) {
            if (parameter != null) {
                throw new ArgumentException(MessageFormatUtil.Format(PdfException.InvalidUsageConfigurationForbidden, "copyrightSince"
                    ));
            }
            // initial value, will be overwritten with product value
            int earliestYear = int.MaxValue;
            foreach (ITextProductEventWrapper @event in events) {
                int currentYear = @event.GetEvent().GetProductData().GetSinceCopyrightYear();
                if (currentYear < earliestYear) {
                    earliestYear = currentYear;
                }
            }
            return earliestYear.ToString();
        }
    }
}