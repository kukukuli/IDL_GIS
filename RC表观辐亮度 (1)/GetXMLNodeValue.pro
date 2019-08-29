;;从xml中提取需要参数
pro GetXMLNodeValue, inXML, inNood, otNoodValue

  oDocument = OBJ_NEW('IDLffXMLDOMDocument')
  oDocument->Load, FILENAME = inXML
  oPlugin = oDocument->GetFirstChild()
  oNodeList = oPlugin->GetElementsByTagName(inNood)
  iNodeCount = oNodeList->GetLength()
  for ii =0,iNodeCount-1 do begin
    oNode = oNodeList->Item(ii)
    oFirstChild = oNode->GetFirstChild()
    strNodeValue = oFirstChild->GetNodeValue()
  endfor
  OBJ_DESTROY, oDocument

  otNoodValue =  strNodeValue

  print,otNoodValue
end