from appium import webdriver
from time import sleep
import datetime
import savedconfig
from appium.webdriver.common.touch_action import TouchAction
from selenium.common.exceptions import NoSuchElementException, StaleElementReferenceException
sc=savedconfig
loop = True

print("10 second to go")
takeSwapTime= 1;
sleep(3)
driver = webdriver.Remote("http://127.0.0.1:4723/wd/hub", sc.caps2)


def click_date():
    pos = sc.datePos[sc.clickDate]
    TouchAction(driver).tap(None, pos, 362, 1).perform()
    print("nav to " + sc.clickDate )
    sleep(3)


def check_exists_by_xpath(xpath):
    try:
        driver.find_element_by_xpath(xpath)
    except NoSuchElementException:
        return False
    return True


def check_filter_applied():
    filter_Applied = False
    while filter_Applied == False:
        try:
            driver.find_element_by_xpath(
                "//android.view.View[@text = 'Applied filters: Quarry bay walker 00:00-23:59']")
            print("filter applied")
            filter_Applied = True
            continue
        except NoSuchElementException:
            #sc.webhook.send("no filter applied...set返個filter!")
            print('set filter please')
            input("please make sure filter is applied , press any key to continue")


"""def apply_for_QuarryBayWalker_filter:
    try:
        driver.find_element_by_xpath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View[1]/android.view.View[2]/android.view.View[2]/android.widget.Image").click()
        TouchAction(driver).press(x=387, y=888).move_to(x=371, y=260).release().perform()"""
check_filter_applied()
while loop == True:
    print('start loop')
    # check take swap exist > find all > click one by one > afterall > refresh
    if check_exists_by_xpath("//android.widget.Button[@text = 'Take swap']"):
        print("搵到take swap !")
        check_filter_applied()
        try:
            allTakeSwap = driver.find_elements_by_xpath("//android.widget.Button[@text = 'Take swap']")
            for i in allTakeSwap:
                try:
                    i.click()
                    sc.webhook.send(
                        datetime.datetime.now().strftime("%m/%d/%Y, %H:%M:%S") + "@everyone 拎到更啦屌你 (take swap )")
                    # print("@everyone 拎到更啦屌你 (take swap )")
                    sleep(takeSwapTime)
                except StaleElementReferenceException:
                    continue
            sleep(2)
            driver.find_element_by_xpath(
                "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View[1]/android.view.View[2]/android.view.View[1]/android.view.View[2]/android.widget.Image").click()
            pass
        except NoSuchElementException:
            pass
    elif check_exists_by_xpath("//android.widget.Button[@text = 'Take Shift']"):
        print("搵到take shift !")
        check_filter_applied()
        try:
            allTakeSwap = driver.find_elements_by_xpath("//android.widget.Button[@text = 'Take Shift']")
            for i in allTakeSwap:
                try:
                    i.click()
                    sc.webhook.send(
                        datetime.datetime.now().strftime("%m/%d/%Y, %H:%M:%S") + "@everyone 拎到更啦屌你 (Take Shift )")
                    # print("@everyone 拎到更啦屌你 (Take Shift )")
                    sleep(takeSwapTime)
                    if driver.find_element_by_xpath("//android.view.View[@text ='Shift Details'"):
                        try:
                            driver.find_element_by_xpath(
                                "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View/android.view.View[2]/android.view.View[1]/android.widget.Image").click()
                        except NoSuchElementException:
                            continue
                except StaleElementReferenceException:
                    continue
            sleep(takeSwapTime)
            driver.find_element_by_xpath(
                "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View[1]/android.view.View[2]/android.view.View[1]/android.view.View[2]/android.widget.Image").click()
            continue
        except NoSuchElementException:
            continue
        # click refresh
    elif check_exists_by_xpath(
            "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View[1]/android.view.View[2]/android.view.View[1]/android.view.View[2]/android.widget.Image"):
        print("refreshing")
        driver.find_element_by_xpath(
            "/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.FrameLayout[2]/android.widget.FrameLayout/android.webkit.WebView/android.webkit.WebView/android.view.View[1]/android.view.View[2]/android.view.View[1]/android.view.View[2]/android.widget.Image").click()
        continue
    # Check if "ok" notification pop up
    elif check_exists_by_xpath("//android.widget.Button[@text = 'OK']"):
        print("notification pop-up > clicking OK")
        driver.find_element_by_xpath("//android.widget.Button[@text = 'OK']").click()
        sleep(6)
        click_date()
        continue

    # check if bugged login !
    elif check_exists_by_xpath("//android.widget.ImageButton[@content-desc='Navigate up']"):
        print("login bug occured , heading to nav up ")
        driver.find_element_by_xpath("//android.widget.ImageButton[@content-desc='Navigate up']").click()
        sleep(6)
        click_date()
        continue
    # click search shift if not started ~
    elif check_exists_by_xpath(
            "//android.widget.Button[contains(@resource-id,'com.foodora.courier:id/button_action') and @text='SEARCH SHIFTS']"):
        driver.find_element_by_xpath(
            "//android.widget.Button[contains(@resource-id,'com.foodora.courier:id/button_action') and @text='SEARCH SHIFTS']").click()
        sleep(6)
        click_date()
        continue
        # click search swift
    # logging into rooster page
    elif check_exists_by_xpath("//android.widget.ImageButton[@content-desc='open']"):
        print("trying to log to rooster")
        driver.find_element_by_xpath("//android.widget.ImageButton[@content-desc='open']").click()
        sleep(3)
        driver.find_element_by_xpath(
            "//android.widget.TextView[contains(@resource-id , 'com.foodora.courier:id/textview_viewholder_title')]").click()
        print("finished logged in ")
        sleep(6)
        click_date()
        continue
    else:
        print("found nothing!! please restart your app ")
        sc.webhook.send(
            datetime.datetime.now().strftime("%m/%d/%Y, %H:%M:%S") + "中bug呀屌你 ")
        break

"""
click select country
driver.find_element_by_xpath("//android.widget.TextView[contains(@resource-id,'com.foodora.courier:id/country_selection_text')]").click()
sleep(2)
#click search
driver.find_element_by_xpath("//android.widget.EditText[contains(@resource-id,'com.foodora.courier:id/edit_select_country_search')]").send_keys('Hong Kong')
sleep(2)
#click Hong Kong
driver.find_element_by_xpath("/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.LinearLayout/androidx.recyclerview.widget.RecyclerView/android.widget.TextView").click()
sleep(2)
#type id
sleep(2)
driver.find_element_by_xpath('/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.widget.RelativeLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.LinearLayout[1]/android.widget.FrameLayout/android.widget.EditText').send_keys(idName)
#type pw
sleep(2)
driver.find_element_by_xpath('/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.widget.RelativeLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.LinearLayout[2]/android.widget.FrameLayout/android.widget.EditText').send_keys(password)
#click login
sleep(2)
driver.find_element_by_xpath('/hierarchy/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.view.ViewGroup/android.widget.ScrollView/android.widget.RelativeLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.FrameLayout/android.widget.LinearLayout/android.widget.LinearLayout[3]/android.widget.Button[1]').click()
sleep(2)
"""
