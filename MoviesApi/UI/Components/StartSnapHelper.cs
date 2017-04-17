using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace MoviesApi.UI.Components
{
    public class StartSnapHelper : LinearSnapHelper
    {
        private OrientationHelper mVerticalHelper, mHorizontalHelper;

        public StartSnapHelper()
        {

        }

        public override void AttachToRecyclerView(RecyclerView recyclerView)
        {
            base.AttachToRecyclerView(recyclerView);
        }

        public override int[] CalculateDistanceToFinalSnap(RecyclerView.LayoutManager layoutManager, View targetView)
        {
            int[] outt = new int[2];

            if (layoutManager.CanScrollHorizontally())
            {
                outt[0] = distanceToStart(targetView, getHorizontalHelper(layoutManager));
            }
            else
            {
                outt[0] = 0;
            }

            if (layoutManager.CanScrollVertically())
            {
                outt[1] = distanceToStart(targetView, getVerticalHelper(layoutManager));
            }
            else
            {
                outt[1] = 0;
            }
            return outt;
        }

        public override View FindSnapView(RecyclerView.LayoutManager layoutManager)
        {
            if (layoutManager.GetType() == typeof(LinearLayoutManager))
            {

                if (layoutManager.CanScrollHorizontally())
                {
                    return getStartView(layoutManager, getHorizontalHelper(layoutManager));
                }
                else
                {
                    return getStartView(layoutManager, getVerticalHelper(layoutManager));
                }
            }

            return base.FindSnapView(layoutManager);
        }

        private int distanceToStart(View targetView, OrientationHelper helper)
        {
            return helper.GetDecoratedStart(targetView) - helper.StartAfterPadding;
        }

        private View getStartView(RecyclerView.LayoutManager layoutManager, OrientationHelper helper)
        {

            if (layoutManager.GetType() == typeof(LinearLayoutManager))
            {
                int firstChild = ((LinearLayoutManager)layoutManager).FindFirstVisibleItemPosition();

                bool isLastItem = ((LinearLayoutManager)layoutManager)
                        .FindLastCompletelyVisibleItemPosition()
                        == layoutManager.ItemCount - 1;

                if (firstChild == RecyclerView.NoPosition || isLastItem)
                {
                    return null;
                }

                View child = layoutManager.FindViewByPosition(firstChild);

                if (helper.GetDecoratedEnd(child) >= helper.GetDecoratedMeasurement(child) / 2
                        && helper.GetDecoratedEnd(child) > 0)
                {
                    return child;
                }
                else
                {
                    if (((LinearLayoutManager)layoutManager).FindLastCompletelyVisibleItemPosition()
                            == layoutManager.ItemCount - 1)
                    {
                        return null;
                    }
                    else
                    {
                        return layoutManager.FindViewByPosition(firstChild + 1);
                    }
                }
            }
            return base.FindSnapView(layoutManager);
        }

        private OrientationHelper getVerticalHelper(RecyclerView.LayoutManager layoutManager)
        {
            if (mVerticalHelper == null)
            {
                mVerticalHelper = OrientationHelper.CreateVerticalHelper(layoutManager);
            }
            return mVerticalHelper;
        }

        private OrientationHelper getHorizontalHelper(RecyclerView.LayoutManager layoutManager)
        {
            if (mHorizontalHelper == null)
            {
                mHorizontalHelper = OrientationHelper.CreateHorizontalHelper(layoutManager);
            }
            return mHorizontalHelper;
        }
    }
}