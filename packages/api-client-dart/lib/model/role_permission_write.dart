//
// AUTO-GENERATED FILE, DO NOT MODIFY!
//
// @dart=2.7

// ignore_for_file: unused_import

import 'package:built_collection/built_collection.dart';
import 'package:built_value/built_value.dart';
import 'package:built_value/serializer.dart';

part 'role_permission_write.g.dart';

abstract class RolePermissionWrite implements Built<RolePermissionWrite, RolePermissionWriteBuilder> {

    @BuiltValueField(wireName: r'companyId')
    String get companyId;

    @BuiltValueField(wireName: r'userId')
    String get userId;

    @BuiltValueField(wireName: r'permissionIds')
    BuiltList<String> get permissionIds;

    RolePermissionWrite._();

    static void _initializeBuilder(RolePermissionWriteBuilder b) => b;

    factory RolePermissionWrite([void updates(RolePermissionWriteBuilder b)]) = _$RolePermissionWrite;

    @BuiltValueSerializer(custom: true)
    static Serializer<RolePermissionWrite> get serializer => _$RolePermissionWriteSerializer();
}

class _$RolePermissionWriteSerializer implements StructuredSerializer<RolePermissionWrite> {

    @override
    final Iterable<Type> types = const [RolePermissionWrite, _$RolePermissionWrite];
    @override
    final String wireName = r'RolePermissionWrite';

    @override
    Iterable<Object> serialize(Serializers serializers, RolePermissionWrite object,
        {FullType specifiedType = FullType.unspecified}) {
        final result = <Object>[];
        result
            ..add(r'companyId')
            ..add(serializers.serialize(object.companyId,
                specifiedType: const FullType(String)));
        result
            ..add(r'userId')
            ..add(serializers.serialize(object.userId,
                specifiedType: const FullType(String)));
        result
            ..add(r'permissionIds')
            ..add(serializers.serialize(object.permissionIds,
                specifiedType: const FullType(BuiltList, [FullType(String)])));
        return result;
    }

    @override
    RolePermissionWrite deserialize(Serializers serializers, Iterable<Object> serialized,
        {FullType specifiedType = FullType.unspecified}) {
        final result = RolePermissionWriteBuilder();

        final iterator = serialized.iterator;
        while (iterator.moveNext()) {
            final key = iterator.current as String;
            iterator.moveNext();
            final dynamic value = iterator.current;
            switch (key) {
                case r'companyId':
                    result.companyId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'userId':
                    result.userId = serializers.deserialize(value,
                        specifiedType: const FullType(String)) as String;
                    break;
                case r'permissionIds':
                    result.permissionIds.replace(serializers.deserialize(value,
                        specifiedType: const FullType(BuiltList, [FullType(String)])) as BuiltList<String>);
                    break;
            }
        }
        return result.build();
    }
}

