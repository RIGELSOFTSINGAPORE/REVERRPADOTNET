Public Class MujiClass
	Function ApplySubnetMaskNew(ipaddr, netmask)

		Dim ippart, maskpart

		ippart = Split(ipaddr, ".")
		maskpart = Split(netmask, ".")

		For i = LBound(ippart) To UBound(ippart)


			ippart(i) = ippart(i) And maskpart(i)

		Next

		Return Join(ippart, ".")
		'ApplySubnetMask = Join(ippart, ".")

	End Function
End Class
