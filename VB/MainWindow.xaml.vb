Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Media
Imports System.Collections.ObjectModel

Namespace SchedulerResourceColorsWpf
	Partial Public Class MainWindow
		Inherits Window
		Private resourceCounter As Integer = 0

		Public Sub New()
			InitializeComponent()

			Me.DataContext = New ObservableCollection(Of ModelResource)()
		End Sub

		Private Sub btnAddResource_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If colorEdit.EditValue Is Nothing Then
				Return
			End If

			resourceCounter += 1

			CType(Me.DataContext, ObservableCollection(Of ModelResource)).Add(New ModelResource() With {.Id = resourceCounter, .Name = "Resource" & resourceCounter.ToString(), .Color = CInt(Fix(colorEdit.EditValue))})
		End Sub
	End Class

	Public Class ModelResource
		Private privateId As Integer
		Public Property Id() As Integer
			Get
				Return privateId
			End Get
			Set(ByVal value As Integer)
				privateId = value
			End Set
		End Property
		Private privateName As String
		Public Property Name() As String
			Get
				Return privateName
			End Get
			Set(ByVal value As String)
				privateName = value
			End Set
		End Property
		Private privateColor As Integer
		Public Property Color() As Integer
			Get
				Return privateColor
			End Get
			Set(ByVal value As Integer)
				privateColor = value
			End Set
		End Property

		Public Sub New()

		End Sub
	End Class

	Public Class CustomColorConverter
		Inherits System.Windows.Markup.MarkupExtension
		Implements System.Windows.Data.IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
			If TypeOf value Is Integer Then
				Dim hexString As String = "#" & (CInt(Fix(value))).ToString("X")
				Dim color As Color = CType(ColorConverter.ConvertFromString(hexString), Color)
			End If

			Return value
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
			Dim color As Color = CType(value, Color)
			Dim result As Integer = BitConverter.ToInt32(New Byte() { color.B, color.G, color.R, color.A }, 0)

			Return result
		End Function

		Public Overrides Function ProvideValue(ByVal serviceProvider As IServiceProvider) As Object
			Return Me
		End Function
	End Class
End Namespace