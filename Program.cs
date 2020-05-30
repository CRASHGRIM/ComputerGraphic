using System;
using System.Windows.Forms;
using Autofac;
using Autofac.Core;
using CGG_1_2.Actions;
using CGG_1_2.Brezenham;
using CGG_1_2.Common;
using CGG_1_2.FlHorizon;
using CGG_1_2.PixelGraph;
using CGG_1_2.Roberts;
using TagsCloudForm.Actions;
using TagsCloudForm.Common;
using TagsCloudForm.Polyhedron_Diff;
using TagsCloudForm.UiActions;

namespace TagsCloudForm
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CloudForm>().As<CloudForm>();
            builder.RegisterType<Palette>().As<IPalette>().SingleInstance();
            RegisterActions(builder);
            RegisterSettingsClasses(builder);
            builder.RegisterType<XmlObjectSerializer>().As<IObjectSerializer>();
            builder.RegisterType<FileBlobStorage>().As<IBlobStorage>();
            builder.RegisterType<PictureBoxImageHolder>().As<IImageHolder, PictureBoxImageHolder>().SingleInstance();
            builder.RegisterType<GraphDrawingLogicFactory>();
            builder.RegisterType<PolarGraphLogicFactory>();
            builder.RegisterType<BrezenhamLogicFactory>();
            builder.RegisterType<PolyhedronFactory>();
            builder.RegisterType<FlHorizonFactory>();
            builder.RegisterType<RobertsFactory>();

            var container = builder.Build();
            var form = container.Resolve<CloudForm>();
            Application.Run(form);
        }
        

        private static void RegisterActions(ContainerBuilder builder)
        {
            builder.RegisterType<GraphDrawAction>().As<IUiAction>();
            builder.RegisterType<PolarGraphDrawAction>().As<IUiAction>();
            builder.RegisterType<SaveImageAction>().As<IUiAction>();
            builder.RegisterType<PaletteSettingsAction>().As<IUiAction>();
            builder.RegisterType<GraphicDrawer>().As<IGraphicDrawer>();
            builder.RegisterType<GraphSettingsAction>().As<IUiAction>();
            builder.RegisterType<PolarGraphSettingsAction>().As<IUiAction>();
            builder.RegisterType<BrezenhamSettingsAction>().As<IUiAction>();
            builder.RegisterType<BrezenhamAction>().As<IUiAction>();
            builder.RegisterType<PolyhedronAction>().As<IUiAction>();
            builder.RegisterType<PolyhedronSettingsAction>().As<IUiAction>();
            builder.RegisterType<FlHorizonAction>().As<IUiAction>();
            builder.RegisterType<FlHorizonSettingsAction>().As<IUiAction>();
            builder.RegisterType<RobertsAction>().As<IUiAction>();
            builder.RegisterType<RobertsSettingsAction>().As<IUiAction>();
        }

        private static void RegisterSettingsClasses(ContainerBuilder builder)
        {
            builder.RegisterType<GraphSettings>().As<GraphSettings>().SingleInstance();
            builder.RegisterType<PolarSettings>().As<PolarSettings>().SingleInstance();
            builder.RegisterType<BrezenhamSettings>().As<BrezenhamSettings>().SingleInstance();
            builder.RegisterType<PolyhedronSettings>().As<PolyhedronSettings>().SingleInstance();
            builder.RegisterType<FlHorizonSettings>().As<FlHorizonSettings>().SingleInstance();
            builder.RegisterType<RobertsSettings>().As<RobertsSettings>().SingleInstance();
            builder.Register(x => x.Resolve<AppSettings>().ImageSettings).As<ImageSettings>().SingleInstance();
            builder.RegisterType<SettingsManager>().As<SettingsManager>();
            builder.Register(x => x.Resolve<SettingsManager>().Load()).As<AppSettings, IImageDirectoryProvider>().SingleInstance();
        }
    }
}
