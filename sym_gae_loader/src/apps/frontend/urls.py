# -*- coding: utf-8 -*-
from tipfy import Rule, Submount

def get_rules(app):
    """Returns a list of URL rules for the Hello, World! application.

    :param app:
        The WSGI application instance.
    :return:
        A list of class:`tipfy.Rule` instances.
    """
    rules = [
          Rule('/load_users'                      , endpoint='load_users'             , handler='apps.frontend.handlers.IduOduLoader'),
          Rule('/get_profiles'                    , endpoint='get_profiles'           , handler='apps.frontend.handlers.Profiles'),
          Rule('/get_sfguard'                     , endpoint='get_sfguard'            , handler='apps.frontend.handlers.SFGuardUsers'),
        ]
        
    return rules
