/* Uyanık Kütüphane — admin shell: sidebar + topbar (branch selector + user menu). */
const LMDS = window.MetronicDesignSystem_a73f8f;
const LIB_LOGO_URI = "data:image/svg+xml;utf8,%3Csvg%20xmlns%3D%22http%3A%2F%2Fwww.w3.org%2F2000%2Fsvg%22%20viewBox%3D%22222.03%20275.16%201547.99%201562.46%22%3E%3Cg%20transform%3D%22matrix(1%2C0%2C0%2C-1%2C0%2C2000)%22%3E%3Cpath%20d%3D%22M945.28%20950.61C962.03%20943.88%20979.89%20921.79%20988.19%20905.51C991.56%20899.02%20993.44%20891.42%20996.49%20884.92C1003.39%20899.4%201003.47%20907.31%201016.37%20923.75C1024.99%20934.56%201034.07%20943.72%201047.86%20950.77C1042.53%20963.06%201009.48%20991.16%20996.73%20999.62C991.32%20997.36%20973.94%20982%20968.93%20977.69C966.42%20975.59%20965.48%20974.1%20963.14%20971.6C960.71%20968.93%20959.45%20968.15%20956.4%20965.24C953.65%20962.74%20947.16%20954.84%20945.28%20950.61%22%20fill%3D%22%23fda331%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M976.29%201684.84C957.58%201678.88%20962.67%201654.93%20962.67%201634.48L962.67%201506.07C962.67%201496.51%20961.09%201484.77%20965.8%201477.25C969.33%201471.62%20977.55%201465.98%20987.87%201469.19C1006.05%201474.91%201001.34%201498.8%201001.34%201519.14L1001.34%201647.55C1001.34%201656.79%201002.91%201669.02%20998.59%201676.62C994.85%201683.27%20986.07%201687.96%20976.29%201684.84%22%20fill%3D%22%23ffcb43%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1092.1%201668.32C1081.84%201665.81%201072.98%201656.57%201077.93%201642.7C1080.74%201634.64%201129.61%201588.2%201137.43%201580.38C1151.3%201566.51%201164.37%201553.44%201178.22%201539.59C1185.19%201532.61%201191.39%201526.42%201198.34%201519.46C1203.59%201514.21%201212.05%201502.87%201225.68%201506.78C1234.76%201509.36%201243.3%201519.46%201238.43%201532.29C1236.17%201538.33%201184.49%201588.44%201178.62%201594.23C1164.53%201608.1%201151.6%201621.17%201137.67%201635.02C1130.69%201642.08%201124.52%201648.19%201117.54%201655.15C1112.21%201660.48%201104.93%201671.36%201092.1%201668.32%22%20fill%3D%22%23ffcb43%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M864.47%201668.46C853.51%201665.87%20830.18%201639.11%20821.42%201630.25C807.55%201616.4%20794.48%201603.31%20780.61%201589.46C766.76%201575.61%20753.69%201562.44%20739.82%201548.67C734.26%201543.1%20723.62%201535.98%20724.48%201523.45C725.26%201512.25%20736.07%201503.65%20748.19%201506.46C756.41%201508.34%20765.65%201519.55%20770.52%201524.4L872.31%201626.18C877.62%201631.6%20888.51%201639.17%20887.19%201651.86C886.08%201662.2%20875.98%201671.13%20864.47%201668.46%22%20fill%3D%22%23ffcb43%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M414.87%20598.96C415.11%20593.33%20425.37%20570.08%20427.72%20562.32L640.37%20562C640.29%20554.1%20638.51%20546.35%20634.74%20540.31C629.97%20532.56%20627.71%20531.31%20615.96%20531.39L445.72%20531.39C447.68%20525.6%20462.88%20500.92%20466.94%20494.11C501.24%20493.65%20535.86%20494.11%20570.22%20494.11C598.34%20494.11%20631.53%20499.12%20628.63%20448.87L528.18%20448.79C526.76%20428.74%20550.81%20399.92%20558.79%20391.08C626.28%20316.69%20824.22%20249.12%20922.97%20221C944.33%20214.9%20970.97%20206.2%20992.96%20202.38L982.32%20632.16C974.64%20635.85%20958.99%20640.3%20950.15%20643.12C939.26%20646.65%20928.92%20650.26%20918.28%20653.77C851.25%20675.62%20793.78%20695.9%20727.93%20720.26C644.92%20750.94%20561.62%20782.73%20478.77%20813.82L291.23%20884.2C277.84%20889.29%20267.98%20890.24%20262.03%20878.27C256.39%20867.06%20265.96%20856.34%20270.65%20848.42C292.25%20812.48%20313.32%20776.94%20334.61%20741.46L382.78%20661.2C387.47%20653.39%20394.12%20640.86%20398.67%20634.74C422.25%20633.18%20450.35%20634.5%20474.46%20634.5C502.02%20634.5%20607.34%20635.93%20625.66%20634.04C647.67%20631.78%20664.97%20621.59%20665.83%20599.04L414.87%20599.04Z%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1594.15%20634.5C1605.03%20651.34%201615.84%20670.44%201626.34%20688.06L1722.58%20848.66C1727.35%20856.72%201737.69%20868.71%201730.01%20880.13C1722.42%20891.42%201711.53%20888.13%201699.79%20883.42C1679.28%20875.36%201658.05%20867.93%201637.22%20860.01C1595.73%20844.19%201554.78%20828.62%201513.05%20813.34C1429.72%20782.82%201347.04%20751.03%201263.81%20719.77C1242.82%20711.96%201222.16%20704.44%201201.33%20696.28L1139.55%20673.19C1129.21%20669.66%201015.91%20634.66%201010.28%20631.7L1000.1%20202.38C1011.12%20203.86%201056.87%20217.17%201070.42%20221.08C1093.11%20227.65%201117%20234.47%201138.61%20242.07C1161.24%20250.06%201182.37%20256.94%201204.86%20265.18C1265.05%20287.17%201335.15%20317.86%201385.8%20351.77C1412.96%20370.01%201465.66%20412.37%201464.96%20448.79L1364.35%20449.01C1361.85%20498.82%201393.7%20494.11%201423.31%20494.11C1440.3%20494.11%201515.93%20493.25%201526.28%20494.35L1547.26%20530.53C1539.97%20532.8%201404.2%20531.55%201377.58%20531.39C1366.46%20531.31%201363.25%20532.5%201358.4%20540.01C1354.79%20545.57%201352.45%20554.65%201352.75%20562.32L1563.62%20562.32C1566.99%20563.34%201578.11%20597.4%201578.25%20599.04L1327.23%20599.04C1328.25%20622.06%201345.95%20632.48%201368.96%20634.2C1391.98%20636.01%201420.34%20634.58%201443.97%20634.58L1594.15%20634.58Z%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M763.47%201366.92C766.52%201364.66%20769.34%201364.2%20772.95%201362.77C842.63%201335.13%20871.21%201321.98%20931.34%201271.95C936.28%201267.88%20939.8%201263.11%20944.33%201258.8C956.48%201247.44%20969.95%201230.46%20979.11%201215.26C991.72%201194.44%20988.35%201196.86%20995.25%201182.37L996.95%201179.4C1021.95%201251.04%201093.03%201303.5%201155.61%201335.13C1167.03%201340.95%201179.32%201346.66%201191.39%201351.67C1197.48%201354.1%201203.83%201356.68%201210.09%201359.11C1213.3%201360.35%201216.28%201361.37%201219.57%201362.63C1223.02%201363.88%201227.17%201364.82%201229.75%201366.86C1211.19%201367.48%201160.22%201361.37%201135.4%201359.81C1123.03%201358.95%201079.26%201393.48%20997.81%201393.32C914.83%201393.24%20869.49%201360.59%20860.79%201359.73C854.07%201359.11%20835.89%201361.53%20828.07%201362.15C807.79%201363.72%20783.43%201366.86%20763.47%201366.92%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M274.41%20905.27C278.24%20902.46%20435.55%20848.74%20454.04%20842.47C573.74%20801.76%20693.93%20758.14%20813.12%20718.37C843.03%20708.43%20873.48%20698.17%20903%20687.52C916.71%20682.59%20985.45%20656.91%20993.12%20657.54C994.77%20678.36%20976.91%20682.59%20961.09%20689L823.84%20744.29C763.15%20768.72%20702.87%20792.92%20641.4%20817.65L366.96%20927.28C345.27%20935.82%20336.89%20936.9%20315.59%20927.04C311.84%20925.31%20277.22%20908.96%20274.41%20905.27%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1001.1%20657.37C1007.05%20657.45%201162.56%20711.88%201181.28%20718.53L1450.41%20811.78C1480.15%20821.88%201510.46%20832.15%201540.21%20842.79C1559.15%20849.52%201714.82%20901.28%201718.73%20905.59C1715.76%20909.98%201704.17%20914.13%201698.22%20916.94C1672.38%20929.3%201660.64%20941.21%201625.48%20927.28C1595.41%20915.37%201565.72%20902.84%201534.96%20890.4C1474.2%20865.74%201413.68%20841.85%201352.53%20817.19C1291.21%20792.52%201231.08%20768.4%201170.08%20743.89C1139.15%20731.44%201109%20719.69%201078.39%20707.25C1062.74%20700.83%201047.93%20694.96%201032.59%20688.76C1018.88%20683.21%20997.19%20677.5%201001.1%20657.37%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M932.99%20803.4C887.97%20800.36%20886.87%20803.1%20863.15%20835.43C863.37%20809.43%20885.7%20790.17%20911.22%20793.92C915.69%20794.56%20919.14%20795.64%20923.13%20797.23L930.48%20800.74C932.83%20802.62%20931.51%20801.3%20932.99%20803.4%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1061.56%20803.4C1062.96%20801.52%201061.64%20802.86%201063.44%20801.3C1064.54%20800.36%201065%20800.03%201066.19%20799.41C1067.75%20798.55%201069.93%20797.77%201071.42%20797.23C1104.47%20784.54%201131.47%20807.47%201131.39%20835.43C1107.6%20802.38%201105.25%20800.52%201061.56%20803.4%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1013.49%20843.89C1034.62%20814.53%201082%20822.59%201090.06%20857.36C1082.86%20852.89%201075.73%20840.83%201058.11%20836.46C1039.09%20831.67%201028.04%20840.12%201013.49%20843.89%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M980.59%20762.93C965.8%20759.7%20956.4%20751.18%20937.3%20755.55C920.14%20759.56%20913.64%20770.21%20904.56%20776.7C909.11%20755.33%20935.41%20736.85%20962.67%20748.9C969.95%20752.19%20978.09%20757.92%20980.59%20762.93%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1014.03%20762.93C1019.28%20752.51%201040.97%20742.16%201058.27%20745.85C1072.98%20748.98%201087.15%20762.69%201090.06%20776.7C1081.22%20770.37%201074.95%20760.02%201058.11%20755.8C1038.85%20750.86%201029.14%20759.48%201014.03%20762.93%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M980.43%20843.49C962.98%20839.18%20944.65%20826.03%20918.98%20844.89C913.26%20849.12%20909.11%20854.54%20904.56%20857.36C907.93%20843.19%20921%20830.1%20935.49%20826.73C953.57%20822.42%20975.42%20833.39%20980.43%20843.49%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M959.23%20798.63C963.46%20788.13%20981.54%20775.38%20998.92%20776C1016.62%20776.54%201031.81%20789.85%201035.88%20802.08C1017.64%20790.95%201005.65%20778.97%20978.01%20789.71C971.35%20792.28%20965.1%20796.83%20959.23%20798.63%22%20fill%3D%22%238bb4de%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M635.92%201070.72C626.98%201158.74%20692.85%201228.25%20770.36%201236.01C858.52%201244.87%20927.82%201178.86%20935.49%201101.19C944.19%201013.17%20878.41%20944.04%20800.43%20936.28C712.73%20927.66%20643.74%20993.67%20635.92%201070.72M696.14%201266.64L671.94%201251.99C663.71%201246.59%20657.05%201240.56%20649.85%201234.85C646.17%201232.02%20643.12%201228.41%20639.91%201225.21C637.09%201222.46%20632.72%201218.55%20630.13%201215.34C596.53%201173.85%20577.43%201132.42%20581.82%201069.16C584.09%201036.5%20593.01%201006.2%20610.39%20980.36C634.5%20944.42%20671.3%20921.41%20710.15%20903.79C715.54%20901.36%20720.87%20899.64%20724.16%20896.35C699.02%20897.37%20664.51%20907.15%20643.28%20919.68C630.35%20927.28%20628.87%20931.27%20623.56%20934.64C616.34%20924.07%20611.57%20872%20612.73%20856.5C649.23%20844.11%20685.87%20828.78%20722.06%20815.55C740.52%20808.81%20758.46%20801.92%20776.62%20795.02C788.99%20790.33%20822.28%20777.32%20833.79%20775.22C836.45%20829.32%20846.47%20837.16%20874.34%20880.78C894.38%20912.17%20925.63%20963.68%20945.92%20992.03C950.99%20999.08%20956.48%201006.76%20960.95%201014.03C991.94%201064.53%20988.57%201142.6%20964.54%201192.01C934.31%201254.33%20860.57%201291.84%20798.31%201318.53C744.69%201341.57%20687.2%201365.06%20642.8%201400.22C629.27%201410.86%20624.96%201421.04%20616.96%201430.2C611.03%201420.4%20609.3%201387.53%20610.23%201374.3C616.1%201288.55%20690.41%201272.19%20696.14%201266.64%22%20fill%3D%22%23ffffff%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1057.03%201078.32C1052.32%201163.75%201119.02%201232.18%201199.12%201236.57C1285.58%201241.34%201353.69%201173.93%201357.76%201093.43C1362.15%201008.4%201295.28%20939.89%201215.5%20935.82C1129.45%20931.43%201061.4%20997.52%201057.03%201078.32M1159.27%20775.84C1164.83%20775.84%201321.82%20835.89%201352.69%20847.56C1361.53%20850.93%201371.71%20854%201380.17%20858.06C1382.98%20884.76%201374.84%20911.14%201370.23%20935.04C1364.98%20932.75%201368.02%20932.75%201360.34%20926.88C1356.52%20923.99%201354.09%20922.43%201350.02%20919.84C1343.53%20915.69%201333.97%20911.46%201326.29%20908.72C1313.22%20904.11%201298.57%20900.34%201284.64%20898.15L1273.13%20896.65C1272.19%20896.73%201275.31%20893.76%201269.14%20897.99C1293.41%20904.17%201346.57%20938.08%201364.89%20958.29C1389.55%20985.45%201407.49%201017.78%201411.18%201068.7C1415.39%201128.19%201396.53%201177.22%201362.39%201215.5C1354.95%201223.8%201350.56%201227.55%201342.73%201235.07C1324.4%201252.39%201313.06%201255.51%201296.46%201267.02C1314.16%201275.86%201317.99%201274.08%201337.79%201289.03C1380.31%201321.2%201393.16%201378.21%201376.32%201430.83C1370.85%201425.58%201369.75%201415.09%201341.4%201393.16C1327.93%201382.74%201313.46%201374.22%201296.38%201365.28C1210.09%201319.88%201074.87%201284.88%201028.98%201193.03C1011.6%201158.34%201005.11%201112.85%201012.79%201069.4C1019.66%201030.39%201028.2%201019.91%201046.44%20993.13C1077.61%20947.32%201116.3%20885.47%201146.05%20837C1155.05%20822.28%201158.17%20795.64%201159.27%20775.84%22%20fill%3D%22%23ffffff%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1168.84%201050.29C1144.4%201084.57%201193.19%201106.58%201207.2%201077.78C1213.08%201065.63%201207.5%201057.49%201202.57%201050.35C1226.14%201053.58%201250.88%201083.87%201246.59%201117.14C1237.73%201185.28%201137.27%201188.4%201125.38%201119.51C1119.51%201085.59%201143.3%201055.53%201168.84%201050.29%22%20fill%3D%22%23ffffff%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M822.66%201050.35C848.58%201055.07%20871.29%201086.38%20866.52%201117.71C855.86%201187.78%20754.31%201186.76%20744.99%201116.76C740.76%201085.05%20763.31%201055.31%20788.93%201050.3C784.84%201057.87%20778.1%201064.39%20784.38%201077.46C793.46%201096.26%20819.7%201095.24%20827.59%201076.83C833.47%201063.36%20825.87%201055.77%20822.66%201050.35%22%20fill%3D%22%23ffffff%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M822.66%201050.35C825.87%201055.77%20833.47%201063.36%20827.59%201076.83C819.7%201095.24%20793.46%201096.26%20784.38%201077.46C778.1%201064.39%20784.84%201057.87%20788.93%201050.3C763.31%201055.31%20740.76%201085.05%20744.99%201116.76C754.31%201186.76%20855.86%201187.78%20866.52%201117.71C871.29%201086.38%20848.58%201055.07%20822.66%201050.35M635.92%201070.72C643.74%20993.67%20712.74%20927.66%20800.43%20936.28C878.41%20944.04%20944.19%201013.17%20935.49%201101.19C927.82%201178.86%20858.52%201244.87%20770.36%201236.01C692.85%201228.25%20626.98%201158.74%20635.92%201070.72%22%20fill%3D%22%23142a3d%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3Cpath%20d%3D%22M1168.84%201050.29C1143.3%201055.53%201119.51%201085.59%201125.38%201119.51C1137.27%201188.4%201237.73%201185.28%201246.59%201117.14C1250.88%201083.87%201226.14%201053.58%201202.57%201050.35C1207.5%201057.49%201213.08%201065.63%201207.2%201077.78C1193.19%201106.58%201144.4%201084.57%201168.84%201050.29M1057.03%201078.32C1061.4%20997.52%201129.45%20931.43%201215.5%20935.82C1295.28%20939.89%201362.15%201008.4%201357.76%201093.43C1353.69%201173.93%201285.58%201241.34%201199.12%201236.57C1119.02%201232.18%201052.31%201163.75%201057.03%201078.32%22%20fill%3D%22%23142a3d%22%20fill-rule%3D%22evenodd%22%3E%3C%2Fpath%3E%3C%2Fg%3E%3C%2Fsvg%3E";

const LIB_SHELL_CSS = `
.lb-app{display:flex;min-height:100%;background:var(--surface-page);}
.lb-side{width:252px;flex:none;background:var(--color-primary-accent,#14233f);
  display:flex;flex-direction:column;position:sticky;top:0;height:100vh;}
.lb-side__brand{display:flex;align-items:center;gap:11px;height:64px;padding:0 22px;flex:none;
  border-bottom:1px solid rgba(255,255,255,.08);}
.lb-side__brand img{height:30px;}
.lb-side__brand .wm{font-family:var(--font-wordmark);font-weight:800;font-size:18px;letter-spacing:-0.01em;color:#fff;}
.lb-side__scroll{flex:1;overflow-y:auto;padding:14px 14px 22px;}
.lb-side__scroll::-webkit-scrollbar{width:6px;}
.lb-side__scroll::-webkit-scrollbar-thumb{background:rgba(255,255,255,.14);border-radius:3px;}
.lb-side__sec{margin-top:18px;padding:0 10px 8px;font:var(--fw-semibold) 10.5px/1 var(--font-sans);
  letter-spacing:.09em;text-transform:uppercase;color:rgba(255,255,255,.38);}
.lb-side__sec:first-child{margin-top:2px;}
.lb-nav{appearance:none;width:100%;border:0;background:none;cursor:pointer;text-align:left;
  display:flex;align-items:center;gap:12px;padding:9px 11px;border-radius:var(--radius-md);
  font:var(--fw-medium) 13.5px/1 var(--font-sans);color:rgba(255,255,255,.72);transition:all .13s;margin-top:2px;}
.lb-nav:hover{background:rgba(255,255,255,.07);color:#fff;}
.lb-nav--active{background:var(--color-primary);color:#fff;font-weight:var(--fw-semibold);
  box-shadow:0 2px 8px rgba(0,0,0,.18);}
.lb-nav__ic{flex:none;color:inherit;opacity:.92;}
.lb-nav__count{margin-left:auto;font:var(--fw-semibold) 10.5px/1 var(--font-sans);
  background:var(--color-accent);color:#fff;padding:3px 7px;border-radius:999px;}
.lb-nav--active .lb-nav__count{background:rgba(255,255,255,.22);}

.lb-top{height:64px;flex:none;background:var(--surface-card);border-bottom:1px solid var(--border-default);
  display:flex;align-items:center;justify-content:space-between;padding:0 26px;position:sticky;top:0;z-index:30;}
.lb-top__left{display:flex;align-items:center;gap:18px;}

.lb-branch{position:relative;}
.lb-branch__btn{appearance:none;cursor:pointer;display:flex;align-items:center;gap:10px;height:42px;padding:0 12px;
  border:1px solid var(--border-default);border-radius:var(--radius-md);background:var(--color-grey-50);transition:all .13s;}
.lb-branch__btn:hover{border-color:var(--border-strong);background:#fff;}
.lb-branch__pin{width:30px;height:30px;border-radius:8px;background:var(--color-primary-soft);
  display:flex;align-items:center;justify-content:center;flex:none;}
.lb-branch__txt{display:flex;flex-direction:column;line-height:1.2;text-align:left;}
.lb-branch__txt b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);letter-spacing:var(--ls-tight);}
.lb-branch__txt span{font:var(--fw-medium) 11px/1 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.lb-menu{position:absolute;top:calc(100% + 8px);min-width:240px;background:var(--surface-card);
  border:1px solid var(--border-default);border-radius:var(--radius-lg);box-shadow:var(--shadow-lg);padding:7px;z-index:50;}
.lb-menu--left{left:0;}
.lb-menu--right{right:0;}
.lb-menu__item{appearance:none;width:100%;border:0;background:none;cursor:pointer;text-align:left;
  display:flex;align-items:center;gap:11px;padding:9px 11px;border-radius:var(--radius-md);
  font:var(--fw-medium) 13px/1.2 var(--font-sans);color:var(--text-body);transition:background .12s;}
.lb-menu__item:hover{background:var(--color-grey-100);}
.lb-menu__item--active{background:var(--color-primary-soft);color:var(--color-primary);font-weight:var(--fw-semibold);}
.lb-menu__item small{display:block;font:var(--fw-regular) 11px/1.3 var(--font-sans);color:var(--text-muted);margin-top:2px;}
.lb-menu__item--active small{color:var(--color-primary);opacity:.75;}
.lb-menu__sep{height:1px;background:var(--border-default);margin:6px 4px;}

.lb-search{display:flex;align-items:center;gap:9px;height:42px;width:280px;padding:0 13px;border-radius:var(--radius-md);
  background:var(--color-grey-50);border:1px solid var(--border-default);color:var(--text-placeholder);}
.lb-search:focus-within{border-color:var(--color-primary);background:#fff;}
.lb-search input{border:0;background:none;outline:none;font:var(--fw-medium) 13px/1 var(--font-sans);color:var(--text-heading);width:100%;}
.lb-search kbd{font:var(--fw-semibold) 10px/1 var(--font-sans);color:var(--text-placeholder);
  border:1px solid var(--border-default);border-radius:5px;padding:3px 6px;background:#fff;}
.lb-top__right{display:flex;align-items:center;gap:8px;}
.lb-bell{position:relative;}
.lb-bell__dot{position:absolute;top:7px;right:7px;width:8px;height:8px;border-radius:999px;
  background:var(--color-accent);border:2px solid var(--surface-card);}

.lb-user{position:relative;}
.lb-user__btn{appearance:none;cursor:pointer;display:flex;align-items:center;gap:10px;height:46px;padding:0 8px 0 6px;
  border:0;border-radius:var(--radius-md);background:none;transition:background .13s;margin-left:4px;}
.lb-user__btn:hover{background:var(--color-grey-100);}
.lb-user__txt{display:flex;flex-direction:column;line-height:1.2;text-align:left;}
.lb-user__txt b{font:var(--fw-semibold) 13px/1.2 var(--font-sans);color:var(--text-heading);}
.lb-user__txt span{font:var(--fw-medium) 11px/1 var(--font-sans);color:var(--text-muted);margin-top:2px;}

.lb-main{flex:1;display:flex;flex-direction:column;min-width:0;}
.lb-content{flex:1;padding:26px 28px 36px;}
.lb-pagehd{display:flex;align-items:flex-end;justify-content:space-between;gap:20px;margin-bottom:22px;}
.lb-pagehd h1{font:var(--fw-bold) 22px/1.2 var(--font-sans);letter-spacing:var(--ls-tight);color:var(--text-heading);}
.lb-pagehd p{font:var(--fw-regular) 13px/1.4 var(--font-sans);color:var(--text-muted);margin-top:4px;}
.lb-crumb{display:flex;align-items:center;gap:7px;font:var(--fw-medium) 12px/1 var(--font-sans);color:var(--text-muted);margin-bottom:7px;}
.lb-crumb .sep{color:var(--border-strong);}
.lb-crumb b{color:var(--text-body);font-weight:var(--fw-semibold);}
`;

function injectLibShell(){
  if(document.getElementById('lb-shell-css')) return;
  const el=document.createElement('style');el.id='lb-shell-css';el.textContent=LIB_SHELL_CSS;document.head.appendChild(el);
}

const LIB_NAV = [
  { sec: "Genel", items: [
    { id:"home", label:"Ana Sayfa", icon:"home" },
    { id:"orders", label:"Siparişler", icon:"handcart", count:"12" },
    { id:"products", label:"Ürünler", icon:"notepad-bookmark" },
    { id:"categories", label:"Kategoriler", icon:"category" },
    { id:"stock", label:"Stok / Depo", icon:"folder" },
  ]},
  { sec: "Müşteri & Sadakat", items: [
    { id:"customers", label:"Müşteriler", icon:"people" },
    { id:"campaigns", label:"İndirim & Kampanya", icon:"price-tag" },
    { id:"loyalty", label:"Sadakat", icon:"heart" },
  ]},
  { sec: "Yönetim", items: [
    { id:"users", label:"Kullanıcılar", icon:"profile-circle" },
    { id:"branches", label:"Şubeler & POS", icon:"dots-square" },
    { id:"reports", label:"Raporlar", icon:"chart-line-up" },
    { id:"settings", label:"Ayarlar", icon:"setting-2" },
  ]},
];

const LIB_BRANCHES = [
  { id:"cayyolu", name:"Çayyolu Şubesi", sub:"Ankara · Açık" },
  { id:"bagdat", name:"Bağdat Caddesi", sub:"İstanbul · Açık" },
  { id:"alsancak", name:"Alsancak Şubesi", sub:"İzmir · Açık" },
  { id:"merkez", name:"Merkez Depo", sub:"Ankara · 7/24" },
];

function useClickOutside(ref, onClose){
  React.useEffect(()=>{
    function onDoc(e){ if(ref.current && !ref.current.contains(e.target)) onClose(); }
    document.addEventListener('mousedown', onDoc);
    return ()=>document.removeEventListener('mousedown', onDoc);
  },[onClose]);
}

function LibSidebar({ active, onNavigate }){
  return (
    <aside className="lb-side">
      <div className="lb-side__brand">
        <img src={LIB_LOGO_URI} alt="Uyanık" />
        <span className="wm">Uyanık</span>
      </div>
      <nav className="lb-side__scroll">
        {LIB_NAV.map(group => (
          <div key={group.sec}>
            <div className="lb-side__sec">{group.sec}</div>
            {group.items.map(it => (
              <button key={it.id} className={"lb-nav" + (active===it.id ? " lb-nav--active":"")} onClick={()=>onNavigate(it.id)}>
                <LMDS.Icon className="lb-nav__ic" name={it.icon} size={18} />
                <span>{it.label}</span>
                {it.count && <span className="lb-nav__count">{it.count}</span>}
              </button>
            ))}
          </div>
        ))}
      </nav>
    </aside>
  );
}

function BranchSelector(){
  const [open, setOpen] = React.useState(false);
  const [sel, setSel] = React.useState(0);
  const ref = React.useRef(null);
  useClickOutside(ref, ()=>setOpen(false));
  const b = LIB_BRANCHES[sel];
  return (
    <div className="lb-branch" ref={ref}>
      <button className="lb-branch__btn" onClick={()=>setOpen(o=>!o)}>
        <span className="lb-branch__pin"><LMDS.Icon name="home" size={16} color="var(--color-primary)" /></span>
        <span className="lb-branch__txt"><b>{b.name}</b><span>Şube · POS aktif</span></span>
        <LMDS.Icon name="chevron-down" size={14} color="var(--text-placeholder)" style={{transform:open?'rotate(180deg)':'none',transition:'transform .15s'}} />
      </button>
      {open && (
        <div className="lb-menu lb-menu--left">
          {LIB_BRANCHES.map((br,i)=>(
            <button key={br.id} className={"lb-menu__item"+(i===sel?" lb-menu__item--active":"")} onClick={()=>{setSel(i);setOpen(false);}}>
              <LMDS.Icon name={br.id==="merkez"?"folder":"home"} size={17} color={i===sel?"var(--color-primary)":"var(--text-muted)"} />
              <span>{br.name}<small>{br.sub}</small></span>
              {i===sel && <LMDS.Icon name="check-circle" size={16} color="var(--color-primary)" style={{marginLeft:'auto'}} />}
            </button>
          ))}
          <div className="lb-menu__sep"></div>
          <button className="lb-menu__item"><LMDS.Icon name="setting-2" size={17} color="var(--text-muted)" /><span>Tüm şubeleri yönet</span></button>
        </div>
      )}
    </div>
  );
}

function UserMenu(){
  const [open, setOpen] = React.useState(false);
  const ref = React.useRef(null);
  useClickOutside(ref, ()=>setOpen(false));
  return (
    <div className="lb-user" ref={ref}>
      <button className="lb-user__btn" onClick={()=>setOpen(o=>!o)}>
        <LMDS.Avatar name="Selin Aydın" size={36} status="online" />
        <span className="lb-user__txt"><b>Selin Aydın</b><span>Şube Müdürü</span></span>
        <LMDS.Icon name="chevron-down" size={14} color="var(--text-placeholder)" />
      </button>
      {open && (
        <div className="lb-menu lb-menu--right">
          <button className="lb-menu__item"><LMDS.Icon name="profile-circle" size={17} color="var(--text-muted)" /><span>Profilim</span></button>
          <button className="lb-menu__item"><LMDS.Icon name="setting-2" size={17} color="var(--text-muted)" /><span>Hesap ayarları</span></button>
          <button className="lb-menu__item"><LMDS.Icon name="shield-search" size={17} color="var(--text-muted)" /><span>Etkinlik kaydı</span></button>
          <div className="lb-menu__sep"></div>
          <button className="lb-menu__item" style={{color:'var(--color-danger)'}}><LMDS.Icon name="exit-right" size={17} color="var(--color-danger)" /><span>Çıkış yap</span></button>
        </div>
      )}
    </div>
  );
}

function LibTopbar(){
  return (
    <header className="lb-top">
      <div className="lb-top__left">
        <BranchSelector />
        <div className="lb-search">
          <LMDS.Icon name="magnifier" size={16} />
          <input placeholder="Ürün, sipariş, müşteri ara…" />
          <kbd>⌘K</kbd>
        </div>
      </div>
      <div className="lb-top__right">
        <LMDS.IconButton icon="calendar" aria-label="Takvim" />
        <span className="lb-bell"><LMDS.IconButton icon="message-notif" aria-label="Bildirimler" /><span className="lb-bell__dot"></span></span>
        <UserMenu />
      </div>
    </header>
  );
}

function LibAppShell({ active, onNavigate, children }){
  React.useEffect(()=>{ injectLibShell(); },[]);
  return (
    <div className="lb-app">
      <LibSidebar active={active} onNavigate={onNavigate} />
      <div className="lb-main">
        <LibTopbar />
        <div className="lb-content">{children}</div>
      </div>
    </div>
  );
}

window.LibShell = { LibAppShell };
