;;K-means Main

pro Kmeans,strFile,strSaveFile
;  strPath = 'C:\Users\123\Desktop\wer\'
;  strFile = DIALOG_PICKFILE(PATH=strPath,TITLE='Select DICOM Patient File', FILTER='*.tif')

  iData = Read_tiff(strFile, GEOTIFF=GEOTIFF)
  
  ;;Save
;   strBaseName = File_BaseName(strFile,'.tif')
;   strSaveFile = strBaseName + '-Class.tif'

  
  ;;分类数
  iClassNum = 5
  
  ;;初始中心
  InitClassCenter,iData,iClassNum,otInitCenterPoints
  print,otInitCenterPoints
  
  
  KmeansAlg_gray, iData, otInitCenterPoints, iClassNum, otClassData
  iSize = size(iData, /DIMENSIONS)
  otData = make_array(iSize[0],iSize[1])
  otData[*,*] = otClassData[0,*,*]
  
  write_tiff,strSaveFile,otData, /float,GEOTIFF=GEOTIFF,PLANARCONFIG=2

  print,'***Finish***'
end
