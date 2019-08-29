pro NDWI0824,InputFile=InputFile,InputSaveFile=InputSaveFile
;pro NDWI0824,InputFile,InputSaveFile
    strInputFile = InputFile
    iData = read_tiff(strInputFile,GEOTIFF=varGEO,INTERLEAVE=2)

    iGreen = iData(*,*,1)*1.0
    iNir = iData(*,*,3)*1.0
    iSize = size(iNir,/DIMENSIONS)
    iNs = iSize[0]
    iNl = iSize[1]
    iNDWI = fltarr(iNs,iNl)

    for ii = 0,iNs-1 do begin
      for ij = 0,iNl-1 do begin
        if iGreen[ii,ij] eq 0 and iNir[ii,ij] eq 0 then continue
        iNDWI[ii,ij] = (iGreen[ii,ij]-iNir[ii,ij])/(iGreen[ii,ij]+iNir[ii,ij])
      endfor
    endfor

    write_tiff,InputSaveFile,iNDWI,GEOTIFF=varGEO,/float

end
